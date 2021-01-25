using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PathfinderLogicLibrary.StaticData;

namespace BlazorFrontEnd.Pages.Pathfinder
{
    public partial class PointBuy
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        //Toggles for extra controls
        private bool _showCustomRaceControls = false; //Allow user to enter custom racial bonus/penalties
        private bool _showBonusPicker = false; //For humans, half-humans etc that pick their bonus
        private bool _showCustomStartingPoints = false; //Allow user to enter a custom starting point value
        private bool _shouldHideRacePicker = false; 

        //Constants and readonly values that should probably be in another file
        private static readonly Dictionary<string, int> PointCategoryDictionary = new Dictionary<string, int>
        {
            {"Low Fantasy", 10 },
            {"Normal Fantasy", 15 },
            {"High Fantasy", 20 },
            {"Epic Fantasy", 25 },
            {"Custom Value", -1 }
        };

        //Data for table and controls
        private List<IRaceModel> _raceModelsList = new List<IRaceModel>();
        private IRaceModel _selectedRaceModel = new RaceModel();
        private Dictionary<string, int> _currentRacialBonusDictionary = new Dictionary<string, int>();
        private Dictionary<string, int> _baseStatDictionary = new Dictionary<string, int>();
        private int _points = 0;
        private string _selectedRaceBonusString = "";

        //For race picker tabs
        private Dictionary<string, List<string>> _raceTabs = new Dictionary<string, List<string>>();

        protected override async Task OnParametersSetAsync()
        {
            _raceModelsList = await RaceRepository.GetRaces();
            _raceTabs = GetRaceTabDictionary(_raceModelsList);
            await ResetStats();
        }

        #region UI Interaction

        private void HideCustomControls()
        {
            _showCustomStartingPoints = false;
            _showBonusPicker = false;
            _showCustomRaceControls = false;
        }

        private void ShowBonusPicker()
        {
            HideCustomControls();
            _showBonusPicker = true;
        }

        private void ShowCustomRaceControls()
        {
            HideCustomControls();
            _showCustomRaceControls = true;
        }

        private void ShowRacePickerButtons()
        {
            _shouldHideRacePicker = false;
        }

        private void HideRacePickerButtons()
        {
            _shouldHideRacePicker = true;
        }

        private async Task ResetStats()
        {
            //Reset points
            _points = PointBuyUtil.DefaultStartingPoints;
            //Reset race
            PopulateRaceBonusDictionary();
            //Reset statblock
            ResetBaseStatDictionary();
            //Hide custom controls
            HideCustomControls();

            await SetSelectsToDefaultValues();
        }

        private async Task SetSelectsToDefaultValues()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("setSelected", "selectStartingPoints", PointBuyUtil.DefaultStartingPoints);
            //    await JsRuntime.InvokeVoidAsync("setSelected", $"selectRace", _raceModelsList.FirstOrDefault()?.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Catch exception to keep app from crashing on Javascript errors.
            }
        }

        private void ResetBaseStatDictionary()
        {
            _baseStatDictionary = new Dictionary<string, int>();
            foreach (var stat in StatNames.ListStatNames)
            {
                _baseStatDictionary.Add(stat, PointBuyUtil.DefaultStatValue);
            }
        }

        private void ClearSelectedRace()
        {
            _selectedRaceBonusString = "";
            _selectedRaceModel = new RaceModel();
            SetRaceBonusDictionaryToZero();
        }
        #endregion

        #region Handlers

        private void HandleOnSelectedRace(string selected)
        {
            HideCustomControls();
            ShowRacePickerButtons();
            _selectedRaceModel = _raceModelsList.FirstOrDefault(x => x.Name == selected);
            if (RaceHasCustomBonus(_selectedRaceModel))
            {
                _selectedRaceBonusString = "";
                ShowBonusPicker();
            }
            else
            {
                HideCustomControls();
                _selectedRaceBonusString = $"{GetRaceBonusString(_selectedRaceModel)}";
            }

            PopulateRaceBonusDictionary(_selectedRaceModel);
        }

        private void HandleBonusStatButton(string selectedStatKey)
        {
            SetRaceBonusDictionaryToZero();
            _currentRacialBonusDictionary[selectedStatKey] += 2;
        }

        private void HandleOnUseCustomRace()
        {
            ClearSelectedRace();
            SetRaceBonusDictionaryToZero();
            HideRacePickerButtons();
            _selectedRaceModel = new RaceModel()
            {
                Name = "Custom"
            };
            ShowCustomRaceControls();
        }

        private void HandleOnEnterCustomPoints(ChangeEventArgs e)
        {
            _points = int.Parse(e.Value.ToString());
            ResetBaseStatDictionary();
        }

        private void OnSelectPoints(ChangeEventArgs e)
        {
            _showCustomStartingPoints = false;
            _points = 0;

            var pointsFromUi = int.Parse(e.Value.ToString());
            if (pointsFromUi == -1)
            {
                _showCustomStartingPoints = true;
            }
            else
            {
                _points = int.Parse(e.Value.ToString());
            }
            
            ResetBaseStatDictionary();
        }

        #endregion

        #region Utilities

        private static Dictionary<string, int> GetStatlineFromRaceModel(IRaceModel model)
        {
            var stats = new Dictionary<string, int>
            {
                {StatNames.Strength, model.Strength},
                {StatNames.Dexterity, model.Dexterity},
                {StatNames.Constitution, model.Constitution},
                {StatNames.Intelligence, model.Intelligence},
                {StatNames.Wisdom, model.Wisdom},
                {StatNames.Charisma, model.Charisma}
            };
            return stats;
        }

        private static string GetStatAbbr(KeyValuePair<string, int> stat)
        {
            return stat.Key.Substring(0, 3).ToUpper();
        }

        /// <summary>
        /// Determine if a given race model has bonus stats. If all stats are +0 bonus we can determine that it gets a custom bonus.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Boolean: Whether or not a model is a race with a custom bonus</returns>
        private bool RaceHasCustomBonus(IRaceModel model)
        {
            var stats = GetStatlineFromRaceModel(model);
            foreach (var stat in stats)
            {
                if (stat.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, List<string>> GetRaceTabDictionary(List<IRaceModel> models)
        {
            if (models == null || models.Count == 0)
            {
                return new Dictionary<string, List<string>>();
            }

            var returnDict = new Dictionary<string, List<string>>();
            var categories = models.Select(x => x.Category).Distinct();
            foreach (var category in categories)
            {
                var races = GetRacesForCategory(models, category);
                returnDict.Add(category, races);
            }

            return returnDict;
        }

        private List<string> GetRacesForCategory(List<IRaceModel> models, string category)
        {
            var returnList = models.Where(x => x.Category.ToLower() == category.ToLower()).Select(y => y.Name);

            return returnList.ToList();
        }

        private string GetRaceBonusString(IRaceModel model)
        {
            var bonusList = new List<string>();
            var penaltyList = new List<string>();
            var statLine = GetStatlineFromRaceModel(model);
            //Populate bonuses and penalties
            foreach (var stat in statLine)
            {
                if (stat.Value > 0)
                {
                    bonusList.Add($"+{stat.Value} {GetStatAbbr(stat)}");
                }

                if (stat.Value < 0)
                {
                    penaltyList.Add($"{stat.Value} {GetStatAbbr(stat)}");
                }
            }

            //Build Rreturn string
            return PfStringUtils.BuildRaceBonusString(bonusList, penaltyList);
        }

        #endregion

        #region Race dictionary manip

        private void PopulateRaceBonusDictionary()
        {
            PopulateRaceBonusDictionary(_raceModelsList.FirstOrDefault());
        }

        private void PopulateRaceBonusDictionary(IRaceModel model)
        {
            _currentRacialBonusDictionary = GetStatlineFromRaceModel(model);
        }

        private void SetRaceBonusDictionaryToZero()
        {
            _currentRacialBonusDictionary = GetStatlineFromRaceModel(new RaceModel());
        }

        #endregion

        #region Calculations

        private int CalculateFinal(string stat)
        {
            return _baseStatDictionary[stat] + _currentRacialBonusDictionary[stat];
        }

        private int CalculateMod(int val)
        {
            return PointBuyUtil.CalculateMod(val);
        }

        private void IncreaseStat(string stat)
        {
            var cost = PointBuyUtil.FindIncreaseCost(_baseStatDictionary[stat]);
            if (cost <= _points && _baseStatDictionary[stat] < PointBuyUtil.StatCap)
            {
                _baseStatDictionary[stat]++;
                _points -= cost;
            }
            
        }

        private void DecreaseStat(string stat)
        {
            var cost = PointBuyUtil.FindDecreaseCost(_baseStatDictionary[stat]);
            if (_baseStatDictionary[stat] > PointBuyUtil.StatFloor)
            {
                _baseStatDictionary[stat]--;
                _points += cost;
            }
        }

        #endregion
    }
}
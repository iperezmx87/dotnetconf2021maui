using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HolaXamarin.PlatformSpecific;
using Swapi.Rest;
using Swapi.Rest.SwapiModel;
using Xamarin.Forms;

namespace HolaXamarin.ViewModel
{
    public class SwapiViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Film> _FilmsList;

        public ObservableCollection<Film> FilmsList
        {
            get
            {
                return _FilmsList;
            }
            set
            {
                _FilmsList = value;
                OnPropertyChanged("FilmsList");
            }
        }

        private string _AppVersion;
        public string AppVersion
        {
            get
            {
                return _AppVersion;
            }
            set
            {
                _AppVersion = value;
                OnPropertyChanged("AppVersion");
            }
        }

        public SwapiViewModel()
        {
            FilmsList = new ObservableCollection<Film>();
        }

        private Command _CmdGetFilms;
        public Command CmdGetFilms
        {
            get
            {
                if (_CmdGetFilms == null)
                {
                    _CmdGetFilms = new Command(async () =>
                    {
                        try
                        {
                            FilmsList.Clear();

                            using (SwapiHandler swapiRest = new SwapiHandler())
                            {
                                FilmsList = new ObservableCollection<Film>(await swapiRest.GetFilms());
                            }

                            AppVersion = $"Version: {DependencyService.Get<IAppVersionSpecific>().GetAppVersion()}";
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                        }
                    });
                }

                return _CmdGetFilms;
            }
        }

        #region MVVM notify

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

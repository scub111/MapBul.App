﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Map_Bul_App.Models;
using Map_Bul_App.Models.Tables;
using Map_Bul_App.ResX;
using Map_Bul_App.Settings;
using Map_Bul_App.Views;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Map_Bul_App.ViewModel
{
    public class PinDetailsViewModel : BaseViewModel
    {
        public PinDetailsViewModel()
        {
        }

        public event EventHandler PinDeleted;

        public PinDetailsViewModel(int id)
        {
            PinFromServer = ApplicationSettings.Service.GetMarkerDetails(id);
            if (PinFromServer == null) return;
            _id = id;
            _pin = new UserPinDescriptor
            {
                Pin = new TKCustomMapPin
                {
                    Id = PinFromServer.Id,
                    Position = new Position(PinFromServer.Lat, PinFromServer.Lng),
                    Title = PinFromServer.Name,
                    Image = PinFromServer.Pin,
                    ShowCallout = false,
                    IsDraggable = false,
                    Subtitle = PinFromServer.Description
                },
                Id = PinFromServer.Id,
                BaseCategoryId = PinFromServer.BaseCategoryId,
                BaseCategoryName = PinFromServer.CategoriesBranch.FirstOrDefault()?.Name ?? "",
                RootCategoryName = PinFromServer.CategoriesBranch.LastOrDefault()?.Name ?? "",
                PinImage = PinFromServer.Pin,
                InfoImage = PinFromServer.Logo,
                Photos =
                    PinFromServer.Photos.Where(
                        path =>
                            path.StartsWith("http://185.76.145.214/") && path.Length > "http://185.76.145.214/".Length)
                        .ToList(),
                PhotosMini = PinFromServer.PhotosMini.Where(
                        path =>
                            path.StartsWith("http://185.76.145.214/") && path.Length > "http://185.76.145.214/".Length)
                        .ToList(),
                Photo = PinFromServer.Photo,
                Name = PinFromServer.Name,
                HexColor = PinFromServer.Color,
                Phones = PinFromServer.Phones.Any() ? PinFromServer.Phones : new List<Phone>(),
                WorkTime = PinFromServer.WorkTime,
                Subcategories = PinFromServer.Subcategories,
                //Phone =
                //    PinFromServer.Phones.Any() ? PinFromServer.Phones.FirstOrDefault(item => item.Primary) : new Phone(),
                Description = "    " + PinFromServer.Description,
                Street = PinFromServer.Street,
                House = PinFromServer.House,
                Adress = PinFromServer.Street + " " + PinFromServer.House,
                IsVisible = true,
                Introduction = PinFromServer.Introduction,
                Tags = PinFromServer.Subcategories.Select(item => item.Name).ToList(),
                WiFi = PinFromServer.Wifi,
                Personal = PinFromServer.Personal,
                HaveRelatedEvents = PinFromServer.HaveRelatedEvents
            };
            var todayWorkTime =
                PinFromServer.WorkTime.FirstOrDefault(
                    d => d.Id.ToDayOfWeek() == DateTime.Now.DayOfWeek);
            _openTime = todayWorkTime?.OpenTime;
            _closeTime = todayWorkTime?.CloseTime;
            _icon = PinFromServer.Icon;
            _isFavorite = ApplicationSettings.CurrentUser.FavoritesPlaces.Any(item => item.ServerId == id);
            _pins = new ObservableCollection<TKCustomMapPin> {_pin.Pin};
            _mapCenter = new Position(_pin.Pin.Position.Latitude, _pin.Pin.Position.Longitude);
            Events =
                ApplicationSettings.Service.GetRelatedEventsFromMarker(_id, true)
                    .Select(i => new RelatedEvent(new ArticleEventItem(i)))
                    .ToList();
        }

        public override void InitilizeFunc(object obj = null)
        {
            MapCenter = new Position(Pin.Pin.Position.Latitude, Pin.Pin.Position.Longitude);
            Device.BeginInvokeOnMainThread(() =>
            {
                ImagesSource = _pin.Photos;
            });
        }

        #region Field

        private UserPinDescriptor _pin;
        private ImageSource _icon;
        private TimeSpan? _openTime;
        private TimeSpan? _closeTime;
        private bool _isFavorite;
        private ObservableCollection<TKCustomMapPin> _pins;
        private Position _mapCenter;

        #endregion

        #region [Property]

        private string _selectedPhoto;
        public string SelectedPhoto
        {
            get { return _selectedPhoto; }
            set
            {
                if (value != _selectedPhoto)
                {
                    _selectedPhoto = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _id;

        private DeserializeGetMarkerDetailsData PinFromServer { get; } = new DeserializeGetMarkerDetailsData();

        public UserPinDescriptor Pin
        {
            get { return _pin; }
            set
            {
                if (value != null && _pin != value)
                    _pin = value;
                OnPropertyChanged();
            }
        }

        public int PinId => Pin.Pin.Id;

        public bool IsPersonal => Pin.Personal;

        public ImageSource Icon
        {
            get { return _icon; }
            set
            {
                if (_icon == value) return;
                _icon = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan? OpenTime
        {
            get { return _openTime; }
            set
            {
                if (value == _openTime) return;
                _openTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(WorkTime));
            }
        }

        private TimeSpan? CloseTime
        {
            get { return _closeTime; }
            set
            {
                if (value == _closeTime) return;
                _closeTime = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(WorkTime));
            }
        }

        public string WorkTime
        {
            get
            {
                if ((OpenTime == null) || (CloseTime == null))
                {
                    return TextResource.Closed;
                }

                return OpenTime.Value.Hours + ":" +
                       (OpenTime.Value.Minutes < 10 ? "0" + OpenTime.Value.Minutes : OpenTime.Value.Minutes.ToString()) +
                       " - " +
                       CloseTime.Value.Hours + ":" +
                       (CloseTime.Value.Minutes < 10
                           ? "0" + CloseTime.Value.Minutes
                           : CloseTime.Value.Minutes.ToString());
            }
        }

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                if (_isFavorite == value) return;
                _isFavorite = value;
                OnPropertyChanged();
            }
        }

        public Position MapCenter
        {
            get { return _mapCenter; }
            set
            {
                if (_mapCenter == value) return;
                _mapCenter = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TKCustomMapPin> Pins
        {
            get { return _pins; }
            set
            {
                if (_pins == value) return;
                _pins = value;
                OnPropertyChanged();
            }
        }

        private List<RelatedEvent> _events;
        public List<RelatedEvent> Events
        {
            get { return _events; }
            set
            {
                if (value != _events)
                {
                    _events = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<string> _imagesSource;
        public List<string> ImagesSource
        {
            get { return _imagesSource; }
            set
            {
                if (value != _imagesSource)
                {
                    _imagesSource = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        public Command GoToCalendareCommand
        {
            get
            {
                return new Command(act =>
                {
                    if (Pin.HaveRelatedEvents)
                    {
                        ApplicationSettings.GoToPage(new EventsView
                        {
                            MarkerId = _id
                        });
                    }
                });
            }
        }

        public Command AddToFavoritesCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsFavorite = !IsFavorite;
                    Task.Run(() =>
                    {
                        if (IsFavorite)
                        {
                            var place = new Place(PinFromServer, IsFavorite);
                            ApplicationSettings.DataBase.SavePlace(place);
                            ApplicationSettings.Service.SaveFavoriteMarker(
                                 ApplicationSettings.CurrentUser.Guid, place.ServerId);
                        }
                        else
                        {
                            ApplicationSettings.DataBase.DeletePlace(Pin.Pin.Id, IdType.ServerId);
                            OnPinDeleted();
                            ApplicationSettings.Service.RemoveFavoriteMarker(
                                ApplicationSettings.CurrentUser.Guid, PinFromServer.Id);
                        }
                    });
                });
            }
        }

        public Command GoToEditPersonalMarkerCommand
        {
            get
            {
                return new Command(act =>
                {
                    ApplicationSettings.GoToPage(new AddPinView(Pin));
                });
            }
        }

        public Command DeselectPhotoCommand=>new Command(() =>
        {
            SelectedPhoto = null;
        });

        protected virtual void OnPinDeleted()
        {
            PinDeleted?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RelatedEvent
    {
        public RelatedEvent(ArticleEventItem eventItem)
        {
            Event = eventItem;
            GoToEventCommand =new Command(act =>
            {
                if (Event != null)
                {
                    ApplicationSettings.GoToPage(new ArticleDetailsView(Event));
                }
            });
        }

        public ArticleEventItem Event { get; set; }

        public string StartDate => Event?.StartDate != null ? Event.StartDate.Value.ToString("dd.MM.yyyy") : "";

        public string Name => Event != null ? Event.Title : "";

        public ICommand GoToEventCommand { get; set; }
    }
}

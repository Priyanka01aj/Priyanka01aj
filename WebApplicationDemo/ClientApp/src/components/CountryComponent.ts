import Country from '../models/Country';
import template from './CountryComponent.html';
import * as ko from 'knockout';
import { observableArray, ObservableArray } from 'knockout';
import LocationService from '../Services/LocationService';
import CountryViewModel from '../models/CountryViewModel';

class CountryComponent {
  countryList: ObservableArray<Country> = ko.observableArray();
  currentView: ko.Observable<string> = ko.observable('list');
  countryViewModel: ko.Observable<CountryViewModel | undefined> = ko.observable();
  loactionService = new LocationService();

  constructor() {
    this.getCountryList();
  }
 
  public getCountryList() {

    this.loactionService.getCountryList().then(data => {
      data.forEach(country => this.countryList.push(country));
    })
    .catch(error => { console.log(error) });
  }
  public createClick() {
    this.countryViewModel(new CountryViewModel());
    this.currentView('create');
  }
  public editClick=(countrynew: Country) =>{
    if ((countrynew.country_Id) && (countrynew.country_Id > 0))
    {
      this.loactionService.getCountryById(countrynew.country_Id).then(country => {
        var countryModel = new CountryViewModel();
        countryModel.country_Id(country.country_Id!);
        countryModel.country_Name(country.country_Name!);
        this.countryViewModel(countryModel);
        this.currentView('create');
      });
    }
  }
  public deleteClick = (countrynew: Country) => {
    if ((countrynew.country_Id) && (countrynew.country_Id > 0)) {
      this.loactionService.deleteCountry(countrynew.country_Id).then((value: Boolean) => {
        if (value) {
          //this.currentView('none');
          this.countryList([]);
          this.getCountryList();
          this.currentView('list');
        }
      });
    }
  }
  public saveSaveCountry(country: Country) {
    this.loactionService.saveCountry(country).then((value: Boolean) => {
      if (value) {
        this.countryList([]);
        this.getCountryList();
        this.currentView('list');
      }
    });
  }
  public editSaveCountry(country: Country) {

      this.loactionService.updateCountry(country.country_Id!, country).then((value: Boolean) => {
        if (value) {
          this.countryList([]);
          this.getCountryList();
          this.currentView('list');
        }

      })
  }
  public setView() {
    this.currentView('list');
  }
  
}

// The default export returns the component details object to register with KO
export default { viewModel: CountryComponent, template: template };
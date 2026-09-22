import Country from '../models/Country';
import template from './CreateCountryComponent.html';
import * as ko from 'knockout';
import { Observable } from 'knockout';
import LocationService from '../Services/LocationService';
import CountryViewModel from '../models/CountryViewModel';
import { observableArray, ObservableArray } from 'knockout';


class CreateCountryComponent {
  newcountry: Observable<CountryViewModel | undefined>=ko.observable();
  loactionService = new LocationService();
 

  constructor(params: { country: Observable<CountryViewModel> }) {
    this.newcountry = params.country;
  }
  
  public backToList = (parent:any) => {
    parent.setView();
  }
  public saveclickCountry=(parent:any)=> {
   let country = new Country();
    country.country_Id = this.newcountry()?.country_Id();
    country.country_Name = this.newcountry()?.country_Name();
    
      if (country.country_Id == 0) {
        parent.saveSaveCountry(country);
      }
      else if (country.country_Id! > 0) {
        parent.editSaveCountry(country);
      }
    
  }
}
export default { viewModel: CreateCountryComponent, template: template };


import * as ko from 'knockout';
import { Observable } from 'knockout';
import LocationService from '../Services/LocationService';

class CountryViewModel {
  locationService = new LocationService();

  country_Id: Observable<number> = ko.observable(0);
  country_Name: Observable<string> = ko.observable('').extend({
    required: {
    message: "Country name is Required",
  },
    
    minLength: 2,
    pattern: {
      message: 'Please enter letters only',
      params: /^[A-Za-z]*$/
    },
    validation: {
      async: true,
      validator:  (data:any,id:any,callback:any)=> {
        (this.locationService.checkCountryExist(data, this.country_Id()).then((value: Boolean) => {
          if (value) { callback(true); }
          else callback(false);
        })) 
      },
      message: 'Country already exist',
    //  params:this.country_Id,
    }
  });
 
}

export default CountryViewModel;
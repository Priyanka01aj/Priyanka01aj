///*import template from './CreateEmployeeComponent.cshtml';
import * as ko from 'knockout';
import { Observable } from 'knockout';
import LocationService from '../Services/LocationService';
//import EmployeeViewModel from '../models/EmployeeViewModel';
import { observableArray, ObservableArray } from 'knockout';
import Country from '../models/Country';
import EmployeeService from '../Services/EmployeeService';
import State from '../models/State';
import City from '../models/City';
import Employee from '../models/Employee';


export class CreateEmployeeComponent {
  id: ko.Observable<number | undefined> = ko.observable(0);
  firstName: ko.Observable<string> = ko.observable('').extend({
    required: {
      message: "First name is Required",
    },
    pattern: {
      message: 'Please enter letters only',
      params: /^[A-Za-z]*$/
    },
   

  });
  lastName: ko.Observable<string> = ko.observable('').extend({
    required: {
      message: "Last name is Required",
    },
    pattern: {
      message: 'Please enter letters only',
      params: /^[A-Za-z]*$/
    },
    
  });
  phone: ko.Observable<number | undefined> = ko.observable().extend({
    required: {
      message: "Phone number is Required",
    },
    pattern: {
      message: 'Invalid Mobile Number.',
      params: /^([0-9]{10})$/
    },

  });
  email: ko.Observable<string> = ko.observable('').extend({
    required: {
      message: "Email Id is Required",
    },
    pattern: {
      message: 'Invalid Email Id',
      params: /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/
    },
    validation: {
      async: true,
      validator: (data: any, num: any, callback: any) => {
        (this.employeeService.checkEmailIdExist(data, this.id()!).then((value: Boolean) => {
          if (value) { callback(true); }
          else callback(false);
        }))
      },
      message: 'Email Id already exist',
      //  params:this.country_Id,
    }

  });
  city: ko.Observable<string> = ko.observable('');
  stateList: ko.ObservableArray<State> = ko.observableArray();
  cityList: ko.ObservableArray<City> = ko.observableArray();
  selectedCountry: ko.Observable<number | undefined> = ko.observable();
  selectedState: ko.Observable<number | undefined> = ko.observable();
  selectedCity: ko.Observable<number | undefined> = ko.observable();

  countryList: ObservableArray<Country> = ko.observableArray();
  loactionService = new LocationService();
  employeeService = new EmployeeService();
  parentComponent: any;

  constructor(params: { parent: any }) {
    this.parentComponent = params.parent;
    this.getCountryList();
    //this.firstName.extend({
    //  required: {
    //    message: "First name is Required",
    //  }
    //});
  
  }
  public changeCountry(stateId:number | undefined) {
    this.stateList([]);
    this.employeeService.getStatesByCountryId(this.selectedCountry()).then(data => {
      data.forEach(st => this.stateList.push(st));
      this.selectedState(stateId);
    })
      .catch(error => { console.log(error) });
  }
  public changeState(cityId:number | undefined) {
    this.cityList([]);
    if (this.selectedState() != undefined) {
      this.employeeService.getCityByStateId(this.selectedState()).then(data => {
        data.forEach(ct => this.cityList.push(ct));
        this.selectedCity(cityId);
      })
        .catch(error => { console.log(error) });
    }
  }

  public getCountryList() {
    this.loactionService.getCountryList().then(data => {
      data.forEach(country => this.countryList.push(country));
    })
      .catch(error => { console.log(error) });
  }
  public saveclickEmployee = (parent: any) => {
    let employee = new Employee();
    employee.id = this.id();
    employee.firstName = this.firstName();
    employee.lastName = this.lastName();
    employee.phone = this.phone();
    employee.email = this.email();
    employee.cityId = this.selectedCity();
    if ((employee.id) == 0) {
      this.employeeService.saveEmployee(employee).then((value: Boolean) => {
        if (value) {
          parent.BackToList();
        }
      });
    }
    else if ((employee.id!) > 0) {
      this.employeeService.updateEmployee(employee.id!,employee).then((value: Boolean) => {
        if (value) {
          parent.BackToList();
        }
      });
    }
  }

  public backToList=(parent:any)=> {
    parent.BackToList();

  }

  public editNewClick = (employee: Employee) => {
        //let newemp = new CreateEmployeeComponent(this.temp);
        this.id(employee.id);
        this.firstName(employee.firstName!);
        this.lastName(employee.lastName!);
        this.phone(employee.phone!);
        this.email(employee.email!);
        this.selectedCountry(employee.city?.state?.country_Id);
       this.changeCountry(employee.city?.state_Id);
       this.selectedState(employee.city?.state_Id);
       this.changeState(employee.cityId);
       this.selectedCity(employee.cityId);
    
  }
}


export default { template: { element: 'create-employee-template' }, viewModel: CreateEmployeeComponent};

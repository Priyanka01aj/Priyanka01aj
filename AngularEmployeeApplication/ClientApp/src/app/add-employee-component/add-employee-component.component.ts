import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import City from '../../models/City';
import Country from '../../models/Country';
import Employee from '../../models/Employee';
import State from '../../models/State';

@Component({
  selector: '[app-add-employee-component]',
  templateUrl: './add-employee-component.component.html',
  styleUrls: ['./add-employee-component.component.css']
})
export class AddEmployeeComponentComponent implements OnInit{
  registerForm!: FormGroup;
  selectedCity: any;


  constructor(private http: HttpClient, private route: Router, private _activatedRoute: ActivatedRoute, private fb: FormBuilder) {
    this.getCountryList();
   
    this.showList = false;
    this.editView = false;
    this.myForm();
  }
  ngOnInit() {

    this._activatedRoute.params.forEach((params: Params) => {
      this.employee!.id = +params['id'];// get the id from url
      this.getEmployeesById(this.employee!.id)
    })
  }

  myForm() {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required,
        Validators.email]],
      phone: ['', [Validators.minLength(10)]],
      cityId: ['', Validators.required],
      country: ['', Validators.required],
      state: ['', Validators.required],
    });
  }
  get registerFormControl() {
    return this.registerForm.controls;
  }
  getEmployeesById(id:any) {
    this.http.get<Employee>("https://localhost:44326/api/Employee/" + id).subscribe(result => {
      console.log(result);
      this.editView=true;
      this.employee = result;
      this.selectedCity = result.cityId;
      this.selectedState = result.city?.state_Id;
      this.selectedCountry = result.city?.state?.country_Id;
      this.getStateList();
      this.getCityList();
    }, error => console.error(error));
  }
  @Input('app-add-employee-component') pData : any;
  baseUrl = "https://localhost:44326/api/Employee";
   public employee = new Employee();

  public showList: boolean;
  public editView: boolean;
  public countryList: Country[] = [];
  public stateList: State[] = [];
  public cityList: City[] = [];
  public selectedCountry:any;
  public selectedState: any;

  public addEmployee(empl: any) {
    this.employee = empl;
    this.employee!.cityId = this.selectedCity;
    if (empl.id > 0) {
      this.http.put<boolean>(this.baseUrl +'/'+ this.employee?.id, this.employee).subscribe(response => {
        this.showList = true;
        this.route.navigate(['/app-employee-component']);
      });
    }
  
    else {
      this.employee.id = 0;
      this.http.post<boolean>(this.baseUrl, this.employee).subscribe(response => {
        this.showList = true;
        this.route.navigate(['/app-employee-component']);
      });
    }
  }

  public getCountryList(){
    this.http.get<Country[]>("https://localhost:44326/api/Country").subscribe(result => {
      this.countryList = result;
    }, error => console.error(error));
  }

  public getStateList() {
    this.http.get<State[]>("https://localhost:44326/api/State" + "/GetStates/" + this.selectedCountry).subscribe(result => {
      this.stateList = result;
    }, error => console.error(error));
  }

  public getCityList() {
    this.http.get<City[]>("https://localhost:44326/api/City" + "/GetCities/" + this.selectedState).subscribe(result => {
      this.cityList = result;
    }, error => console.error(error));
  }

  public changeCountry(event:any) {
    this.stateList = [];
    this.cityList = [];
    this.selectedCountry = event.target.value;
    this.http.get<State[]>("https://localhost:44326/api/" + "State/GetStates/" + this.selectedCountry).subscribe(result => {
      this.stateList = result;
    }, error => console.error(error));
  }

  public changeState(event: any) {
    this.cityList = [];
    this.selectedState = event.target.value;
    this.http.get<City[]>("https://localhost:44326/api/" + "City/GetCities/" + this.selectedState).subscribe(result => {
      this.cityList = result;
    }, error => console.error(error));

  }

  public changeCity(event: any) {
    this.selectedCity = event.target.value;
  }
}


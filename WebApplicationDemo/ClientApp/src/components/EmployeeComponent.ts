import Employee from '../models/Employee';
import template from './EmployeeComponent.html';
import * as ko from 'knockout';
import { observableArray, ObservableArray } from 'knockout';
import EmployeeService from '../Services/EmployeeService';
//import CreateEmployeeComponent from './CreateEmployeeComponent';
import { CreateEmployeeComponent } from './CreateEmployeeComponent';

class EmployeeComponent {
  temp: any = {};
  empId: number | undefined;

  employeeList: ObservableArray<Employee> = ko.observableArray();
  employeeService = new EmployeeService();
  currentView: ko.Observable<string> = ko.observable('list');
  emp: CreateEmployeeComponent = new CreateEmployeeComponent(this.temp);

  constructor() {
    this.getEmployeeList();
  }
  public createClick() {
    this.emp = new CreateEmployeeComponent(this.temp);
    this.currentView('create');
  }
  public getEmployeeList() {
    this.employeeService.getEmployeeList().then(data => {
      data.forEach(employee => this.employeeList.push(employee));
    })
      .catch(error => { console.log(error) });
  }
  
  public BackToList() {
    this.employeeList([]);
    this.getEmployeeList();
    this.currentView('list');
  }
  public editClick=(employee: Employee)=> {
    if (employee.id! > 0) {
      this.employeeService.getEmployeeById(employee.id!).then(employee => {
        this.emp.editNewClick(employee);
        this.currentView('create');
      })
    }
  }
  //public deleteClick = (employee: Employee) => {
  //  this.employeeService.deleteEmployee(employee.id!).then(value => {
  //    if (value) {
  //      this.employeeList([]);
  //      this.getEmployeeList();
  //      this.currentView('list');
  //    }
  //  });
  //}

  public returnIdToDelete = (employee: Employee): number => {
  return this.empId = employee.id!;
}
  public deleteClick = () => {
    this.employeeService.deleteEmployee(this.empId!).then(value => {
      if (value) {
        this.BackToList();
      }
    });
  }
  
}

export default { viewModel: EmployeeComponent, template: template };

























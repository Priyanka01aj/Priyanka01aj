import { Component, OnInit } from '@angular/core';
import { Employee } from './Employee';

@Component({
  selector: 'app-new-component',
  templateUrl: './new-component.component.html',
  styleUrls: ['./new-component.component.css']
})
export class NewComponentComponent {
  public oldEmp: Employee;
  public emp: Employee[];
  constructor() {
    this.emp = [{
      Name : "Priyanka",
      Age : 34
    }, {
        Name: "Monika",
        Age: 23
      }]
    this.oldEmp = {Name:'',Age:0}
  }
  addEmployee(employee: Employee) {
    this.emp.push(employee);
  }

}

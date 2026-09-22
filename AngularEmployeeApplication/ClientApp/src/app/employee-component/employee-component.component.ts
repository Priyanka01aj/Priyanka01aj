import { Component, Inject, Injectable, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AddEmployeeComponentComponent } from '../add-employee-component/add-employee-component.component';
import Employee from '../../models/Employee';

@Injectable()
@Component({
  selector: 'app-employee-component',
  templateUrl: './employee-component.component.html',
  styleUrls: ['./employee-component.component.css']
})
export class EmployeeComponentComponent {
  @ViewChild(AddEmployeeComponentComponent) child !: any;
  public employees: Employee[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.getEmployees();
  }
  getEmployees() {
    this.http.get<Employee[]>("https://localhost:44326/api/Employee").subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }
  Delete(id: number | undefined)
  {
    this.http.delete("https://localhost:44326/api/Employee/" + id).subscribe(result => {
      console.log(result);
      this.getEmployees();
    }, error => console.error(error));

  }
}

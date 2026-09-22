import Employee from '../models/Employee';
import $ from 'jquery';
import State from '../models/State';
import City from '../models/City';

class EmployeeService {
  url = '/api/EmployeeAPI';

  public getEmployeeList(): Promise<Employee[]> {
    return this.getData<Employee[]>(this.url);
  }
  public getData<T>(url: string): Promise<T> {
    return ($.getJSON(url)) as Promise<T>;
  }
  public getStatesByCountryId(countryId:number | undefined): Promise<State[]> {
    return ($.getJSON(this.url + '/' + 'GetStates' + '/' + countryId));
  }
  public getCityByStateId(stateId: number | undefined): Promise<City[]> {
    return ($.getJSON(this.url + '/' + 'GetCities' + '/' + stateId));
  }
  public checkEmailIdExist(data: string, id: number): Promise<Boolean> {
    return ($.getJSON(this.url + '/' + 'GetEmployeeEmail' + '/' + data + '/' + id))
  }
  public saveEmployee(emp: Employee): Promise<Boolean> {
    return this.saveData(this.url,emp);
  }

  public saveData<T>(url: string, data: any): Promise<Boolean> {
    return $.ajax({
      url: url,
      type: 'post',
      dataType: "JSON",
      data: JSON.stringify(data),
      contentType: "application/json charset=utf-8"
    })
  }
  public getEmployeeById(id: number):Promise<Employee> {
    return ($.getJSON(this.url + '/' + id));
  }
  public updateEmployee(id: number, employee: Employee): Promise<Boolean> {
    return this.editData(this.url, id, employee);
  }

  public editData<T>(url: string, id: any, data: any): Promise<Boolean> {
    return $.ajax({
      url: url + '/' + id,
      type: 'put',
      dataType: "JSON",
      data: JSON.stringify(data),
      contentType: "application/json charset=utf-8"
    })
  }
  public deleteEmployee(id: number): Promise<Boolean> {
    return this.deleteData(this.url, id);
  }
  public deleteData(url: string, id: any): Promise<Boolean> {
    return $.ajax({
      url: url + '/' + id,
      type: 'delete',
      dataType: "JSON",
      contentType: "application/json charset=utf-8"
    })
  }
}
export default EmployeeService;
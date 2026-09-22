import Country from '../models/Country';
import $ from 'jquery';

class LocationService {
  
 
 
  url = '/api/CountryAPI';
  public checkCountryExist(data: string,id:number): Promise<Boolean> {
    return this.getCountryExist(this.url,data,id);
  }
  public getCountryExist(url: string, data: string,id:number): Promise<Boolean> {
    return($.getJSON(url+'/'+'GetName'+'/'+data+'/'+id))
  }
  public getCountryById(id: number | undefined): Promise<Country> {
    return this.getDataById<Country>(this.url,id);
  }
  public getDataById<T>(url: string,id:number | undefined): Promise<T> {
    return ($.getJSON(url+'/'+id) as Promise<T>);
  }
  public getCountryList(): Promise<Country[]> {
    return this.getData<Country[]>(this.url);
  }

  public getData<T>(url: string): Promise<T> {
    return ($.getJSON(url)) as Promise<T>;
  }
  public saveCountry(country:Country): Promise<Boolean> {
    return this.saveData(this.url,country);
  }

  public saveData<T>(url: string,data:any): Promise<Boolean> {
    return $.ajax({
      url: url,
      type: 'post',
      dataType: "JSON",
      data: JSON.stringify(data),
      contentType:"application/json charset=utf-8"
    })
  }
  public updateCountry(id:number,country: Country): Promise<Boolean> {
    return this.editData(this.url,id, country);
  }

  public editData<T>(url: string,id:any, data: any): Promise<Boolean> {
    return $.ajax({
      url: url+'/'+id,
      type: 'put',
      dataType: "JSON",
      data: JSON.stringify(data),
      contentType: "application/json charset=utf-8"
    })
  }
  public deleteCountry(id: number):Promise<Boolean> {
    return this.deleteData(this.url, id);
  }
  public deleteData(url: string, id: any): Promise<Boolean> {
    return $.ajax({
      url: url + '/' + id ,
      type: 'delete',
      dataType: "JSON",
     
      contentType: "application/json charset=utf-8"
    })
  }
}
export default LocationService;
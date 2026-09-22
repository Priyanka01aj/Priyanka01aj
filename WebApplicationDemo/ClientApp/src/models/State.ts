import Country from 'models/Country';


class State {

  state_Id: number | undefined;
  state_Name: string | undefined;
  country: Country | undefined;
  country_Id: number | undefined;
}
export default State;
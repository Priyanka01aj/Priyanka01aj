import City from 'models/City';

class Employee {

  id: number | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  phone: number | undefined;
  email: string | undefined;
  cityId: number | undefined;
  city:City | undefined
}
export default Employee;
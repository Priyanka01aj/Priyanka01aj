import * as ko from "knockout";
import * as validation from "knockout.validation";
import template from './app.html';
import Person from './models/person';
import { Observable } from 'knockout';
import Sammy from 'sammy';


class AppViewModel {

  person: Person;
 // testService: TestService = new TestService();
  setView: Observable<string> = ko.observable('Country');
  route: Sammy.Application = Sammy();

  constructor() {
    this.sammyRouteRegistration();
  // These values are hard-coded but could come from a server API request with JSON response
    validation.init(
      {
        decorateElementOnModified: true,
        decorateInputElement: true,
        errorClass: "error-text",
        errorElementClass: "input-validation-error",
        errorsAsTitleOnModified: true,
        insertMessages: false,
        messageTemplate: "",
        messagesOnModified: true,
        parseInputAttributes: false,
        registerExtenders: true
      },
      true
    );
    this.person = new Person(

      'Jon',

      'Keeping',

      ['The Matrix', 'The Shawshank Redemption', 'Upgrade']

    )
    //this.testService.getdata<any>("https://jsonplaceholder.typicode.com/todos/1").then(data => {

    //  this.person.firstName(data.title);

    //  console.log(data)
    //});
  }
  public sammyRouteRegistration = () => {
    this.route.get('/', () => {
      this.setView('');
    })
    this.route.get('#/Country', () => {
      this.setView('Country');
    })
    this.route.get('#/Employee', () => {
      this.setView('Employee');
    }).run();
  }
}



// The default export returns the component details object to register with KO

export default { viewModel: AppViewModel, template: template };
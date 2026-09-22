import * as ko from 'knockout';
require('knockout.validation');

import Person from './models/person';
import Country from './models/Country';

import PersonReadOnly from './components/PersonReadOnly';
import PersonEditable from './components/PersonEditable';
import ProductDetails from './components/ProductDetails';
import CountryComponent from './components/CountryComponent';
import CreateCountryComponent from './components/CreateCountryComponent';
import EmployeeComponent from './components/EmployeeComponent';
import CreateEmployeeComponent from './components/CreateEmployeeComponent';

import AppRoot from './AppViewModel'

import filmsBinding from './bindings/filmsBinding';
//import AppViewModel from './AppViewModel';

ko.components.register('person-read-only', PersonReadOnly);
ko.components.register('person-editable', PersonEditable);
ko.components.register('product-details', ProductDetails);
ko.components.register('country-component', CountryComponent);
ko.components.register('create-country-component', CreateCountryComponent);
ko.components.register('employee-component', EmployeeComponent);
ko.components.register('create-employee-component', require("./components/CreateEmployeeComponent").default);

ko.components.register('app-root', AppRoot);

ko.bindingHandlers.films = filmsBinding;

class App {
  
}


ko.validation.init({
  errorElementClass: 'is-invalid',
  errorMessageClass: 'invalid-feedback',
  decorateInputElement: true
});

// Bind Knockout to the "app" element in "webpack-template/index.html"
ko.applyBindings(new App(), document.getElementById('app'));

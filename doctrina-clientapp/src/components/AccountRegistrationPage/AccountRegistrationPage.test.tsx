import React from 'react';
import ReactDOM from 'react-dom';
import AccountRegistrationPage from './AccountRegistrationPage';

it('It should mount', () => {
  const div = document.createElement('div');
  ReactDOM.render(<AccountRegistrationPage />, div);
  ReactDOM.unmountComponentAtNode(div);
});
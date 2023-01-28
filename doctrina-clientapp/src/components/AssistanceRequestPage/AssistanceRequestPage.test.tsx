import React from 'react';
import ReactDOM from 'react-dom';
import AssistanceRequestPage from './AssistanceRequestPage';

it('It should mount', () => {
  const div = document.createElement('div');
  ReactDOM.render(<AssistanceRequestPage />, div);
  ReactDOM.unmountComponentAtNode(div);
});
import React from 'react';
import ReactDOM from 'react-dom';
import AssistanceProposal from './AssistanceProposal';

it('It should mount', () => {
  const div = document.createElement('div');
  ReactDOM.render(<AssistanceProposal />, div);
  ReactDOM.unmountComponentAtNode(div);
});
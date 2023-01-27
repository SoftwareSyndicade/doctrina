import React, { Component } from 'react';
import logo from './logo.svg';
import './App.scss';
import { Button, Card, InputAdornment, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import { BrowserRouter, HashRouter, Route, Routes } from 'react-router-dom';
import LoginPage from './components/LoginPage/LoginPage';
import ROUTES from './core/routes';
import AccountRegistrationPage from './components/AccountRegistrationPage/AccountRegistrationPage';

class App extends Component{
  render(): React.ReactNode {
      return(
        <BrowserRouter>
          {
            ROUTES.map((route, index) => {                
              return(
                <Routes>
                  <Route 
                    key={index} 
                    path={route.path}
                    element={<route.component/>}
                  />
                </Routes>                
              )
            })
          }
          
        </BrowserRouter>
      )
  }    
}

export default App;

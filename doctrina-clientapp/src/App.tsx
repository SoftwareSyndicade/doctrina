import React, { Component } from 'react';
import logo from './logo.svg';
import './App.scss';
import { Button, Card, InputAdornment, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import { HashRouter, Route, Routes } from 'react-router-dom';
import LoginPage from './components/LoginPage/LoginPage';
import ROUTES from './core/routes';

class App extends Component{
  render(): React.ReactNode {
      return(
        <HashRouter>
          <Routes>
            {
              ROUTES.map((route, index) => {
                return(
                  <Route 
                    key={index} 
                    path={route.path}
                    element={<route.component/>}
                  />
                )
              })
            }

            
          </Routes>
        </HashRouter>
      )
  }    
}

export default App;

import React, { Component, useEffect } from 'react';
import logo from './logo.svg';
import './App.scss';
import { Button, Card, InputAdornment, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import { BrowserRouter, HashRouter, Navigate, Route, Routes } from 'react-router-dom';
import LoginPage from './components/LoginPage/LoginPage';
import  { OPEN_ROUTES, PROTECTED_ROUTES } from './core/routes/routes';
import RouteGuard from './core/routes/RouteGurad';

const App: React.FC = () =>{

  return (
      <BrowserRouter>
        {
          <Routes>
            {
              OPEN_ROUTES.map((route, index) =>{
                return (
                  <Route key={index} path={route.path} element={<route.component/>}/>
                )
              })
            }
            <Route element={<RouteGuard></RouteGuard>}>
              {
                PROTECTED_ROUTES.map((route, index) => {
                  return (
                    <Route path={route.path} element={<route.component/>}/>
                  )
                })
              }
            </Route>
          </Routes>
        }
        
      </BrowserRouter>
  )
}

export default App;

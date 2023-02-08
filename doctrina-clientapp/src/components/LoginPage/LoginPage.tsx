import { Button, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { Component, FC, useState } from 'react';
import IFormField from '../../core/IFormField';
import styles from './LoginPage.module.scss';
import { useNavigate } from 'react-router-dom'
import useAuth from '../../core/auth/useAuth';
import Account from '../../core/auth/models/Account';
import { useAtom } from 'jotai';
import { userAtom } from '../../core/AtomsConfig';

interface LoginForm{
  USERNAME: string,
  PASSWORD: string
}

const LoginPage: React.FC = () => {

  const navigate = useNavigate()
  const [user, setUser] = useAtom(userAtom)

  const [loginForm, setLoginForm] = useState<LoginForm>({
    USERNAME: "",
    PASSWORD: ""
  })

  const [errors, setErrors] = useState([])

  return (
    <Box flexDirection="row" flexWrap="wrap" display="flex" justifyContent='center' className={'wrapper'}>
      <Box m={1} className={`${styles.loginCard}`} height='fit-content'>
        <header className={'padding1015'}>
          <Typography variant="h4">Welcome</Typography>
          <Typography variant="subtitle2">Login to continue to services</Typography>
        </header>

        <ul>
          {errors.map(err => {
            return(<li>{err}</li>)
          })}
        </ul>

        <div className={'padding1015'}>
          <TextField name='USERNAME' id='USERNAME' value={loginForm.USERNAME} label="Username" fullWidth onChange={(e) => {handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
          </TextField>

          <TextField name='PASSWORD' id='PASSWORD' value={loginForm.PASSWORD} label="Password" type="password" fullWidth onChange={(e) => {handleChanges(e)}} style={{marginBottom:'0.75rem'}}></TextField>

          <div style={{textAlign:'right'}}>
            <Button variant="contained" color="primary" onClick={() => {signIn()}}> Log in </Button>            
          </div>
        </div>

        <hr/>

        <div className={'padding1015'}>
          <Typography variant="h4">Not yet registered?</Typography>
          <Typography variant="subtitle2">Click on register to continue.</Typography>

          <div style={{textAlign:'right', marginTop:'0.75rem'}}>
            <Button variant="contained" color="primary" href='/register'> Register </Button>            
          </div>
        </div>

      </Box>
    </Box>
  )

  function handleChanges(e: React.ChangeEvent){

    let field = e.target as HTMLInputElement

    setLoginForm({
      ... loginForm,
      [field.name]: field.value
    })
  }

  async function signIn(){
    fetch("/v1/auth/sign-in", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      }, 
      body: JSON.stringify(loginForm)
    }).then(res => {
      switch(res.status){
        case 200:{

          res.json().then(data =>{
            if(data.IS_VALIDATED){
              let account: Account = {
                ID: data.ACCOUNT_ID,
                NAME: data.NAME,
                ACCOUN_TYPE: data.ACCOUNT_TYPE,
                ACCESS_TOKEN: data.ACCESS_TOKEN,
                IS_AUTHENTICATED: data.IS_VALIDATED
              }
              
              setUser(account)
              
              localStorage.setItem("ACCOUNT", JSON.stringify(account))

              navigate("/home")
            }
          })
          break
          
        }        
          
        case 400:
          break
        case 401:
          res.json().then((data) => {
            setErrors(data.ERRORS)
          })
          break        
      }
    })
  }
}

export default LoginPage
import { Button, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { Component, FC } from 'react';
import IFormField from '../../core/IFormField';
import styles from './LoginPage.module.scss';
interface ILoginPageState{
  USERNAME: IFormField,
  PASSWORD: IFormField
  ERRORS: string[]
}


class LoginPage extends Component<{}, ILoginPageState>{

  constructor(props: any) {
    super(props)
  }

  render(): React.ReactNode {
      return(
        <Box flexDirection="row" flexWrap="wrap" display="flex" justifyContent='center' className={'wrapper'}>
          <Box m={1} className={`${styles.loginCard}`} height='fit-content'>
            <header className={'padding1015'}>
              <Typography variant="h4">Welcome</Typography>
              <Typography variant="subtitle2">Login to continue to services</Typography>
            </header>

            <ul>
              {this.state.ERRORS.map(err => {
                return(<li>{err}</li>)
              })}
            </ul>

            <div className={'padding1015'}>
              <TextField 
                name="USERNAME"
                helperText={this.state.USERNAME.ERROR}
                label="Username" 
                variant="outlined" 
                error = {!this.state.USERNAME.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  this.handleChanges(e)
                }}
              />

              <TextField
                name="PASSWORD"
                type="password"
                helperText={this.state.PASSWORD.ERROR}
                error = {!this.state.PASSWORD.IS_VALID}                
                label="Password" 
                variant="outlined" 
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {
                  this.handleChanges(e)
                }}
              />

              <div style={{textAlign:'right'}}>
                <Button variant="contained" color="primary" onClick={() => this.signIn()}> Log in </Button>            
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
  }

  async signIn(){

    if(this.state.PASSWORD.IS_TOUCHED && this.state.PASSWORD.IS_TOUCHED){
      let response = await fetch("/v1/auth/sign-in", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "USERNAME": this.state.USERNAME.VALUE,
          "PASSWORD": this.state.PASSWORD.VALUE
        })
      })

      response.json().then((res) => {
        if(!res.IS_VALIDATED){
          this.setState({
            ... this.state,
            ERRORS: res.ERRORS
          })
        }
      })
    }
    
  }

  handleChanges(e: React.ChangeEvent){
    let field = e.target as HTMLInputElement

    switch(field.name){
      case "USERNAME": {
        let fieldState = this.state.USERNAME

        if(field.value.trim() == ""){
          fieldState.IS_VALID = false
          fieldState.ERROR = "Username is mandatory"
        }
        else if(field.value.trim().length < 5) {
          fieldState.IS_VALID = false
          fieldState.ERROR = "Username must be of 5 characters."
        }
        else {
          fieldState.IS_VALID = true
          fieldState.ERROR = ""
          fieldState.VALUE = field.value
        }

        this.setState({
          ... this.state,
          [field.name]: fieldState
        })

        break
      }
        
      case "PASSWORD": {
        let fieldState = this.state.PASSWORD

        if(field.value.trim() == ""){
          fieldState.IS_VALID = false
          fieldState.ERROR = "Password is mandatory"
        }
        else if(field.value.trim().length < 8) {
          fieldState.IS_VALID = false
          fieldState.ERROR = "Password must be of 8 characters."
        }
        else {
          fieldState.IS_VALID = true
          fieldState.ERROR = ""
          fieldState.VALUE = field.value
        }

        this.setState({
          ... this.state,
          [field.name]: fieldState
        })

        break
      }
    }
    
  }
}

export default LoginPage
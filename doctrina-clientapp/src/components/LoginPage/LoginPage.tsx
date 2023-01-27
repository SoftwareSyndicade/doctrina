import { Button, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { Component, FC } from 'react';
import styles from './LoginPage.module.scss';

interface IFormField{
  VALUE: string
  IS_VALID: boolean
  ERROR?: string
}

interface ILoginPageState{
  USERNAME: IFormField,
  PASSWORD: IFormField
  ERRORS: string[]
}


class LoginPage extends Component<{}, ILoginPageState>{

  constructor(props: any) {
    super(props)

    this.state = {
      USERNAME: {
        VALUE: "",
        IS_VALID: true,
        ERROR: ""
        
      },
      PASSWORD: {
        VALUE: "",
        IS_VALID: true,
        ERROR: ""
      },
      ERRORS: []
    }
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
                style={{width:'100%'}}
                onChange={(e) => {
                  this.handleChanges(e)
                }}
              />

              <div style={{textAlign:'right'}}>
                <Button variant="contained" color="primary" onClick={() => this.signIn()}> Log in </Button>            
              </div>
            </div>
          </Box>
        </Box>
      )
  }

  signIn(){
    // validate states before submitting
    // if(this.validateFrom()){
    //   fetch("/v1/auth/sign-in", {
    //     method: 'POST',
    //     body: JSON.stringify(""),
        
        
    //   })
    // }
    
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
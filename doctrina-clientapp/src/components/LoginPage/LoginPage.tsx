import { Button, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { Component, FC } from 'react';
import IFormField from '../../core/IFormField';
import styles from './LoginPage.module.scss';
interface ILoginPageState{
  FORM: {
    USERNAME: "",
    PASSWORD: ""
  }
  ERRORS: string[]
}


class LoginPage extends Component<{}, ILoginPageState>{

  constructor(props: any) {
    super(props)

    this.state =({
      FORM: {
        USERNAME: "",
        PASSWORD: "",
      },      
      ERRORS: []
    })
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
              
              <TextField name='USERNAME' id='USERNAME' value={this.state.FORM.USERNAME} label="Username" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
              </TextField>

              <TextField name='PASSWORD' id='PASSWORD' value={this.state.FORM.PASSWORD} label="Password" type="password" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
              </TextField>

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

    let response = await fetch("/v1/auth/sign-in", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      }, 
      body: JSON.stringify(this.state.FORM)
    })

    response.json().then(res => {
      switch(res.status){
        case 400:{          
          break
        }
          
        case 401:{
          this.setState({
            ... this.state,
            ERRORS: res.ERRORS
          })
          break
        }
      }            
    })    

      
    
  }

  handleChanges(e: React.ChangeEvent){
    let field = e.target as HTMLInputElement

    this.setState({
      ... this.state,
      FORM: {
        ... this.state.FORM,
        [field.name]: field.value
      }
      
    })
  }
}

export default LoginPage
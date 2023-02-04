import { TextFields } from '@mui/icons-material';
import { Button, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { ChangeEvent, Component, FC } from 'react';
import IFormField, { IForm, validateFromField } from '../../core/IFormField';
import styles from './AccountRegistrationPage.module.scss';

interface IAccountRegistrationState{
  FORM: {
    USERNAME: string
    PASSWORD: string
    CONFIRM_PASSWORD: string,
    ACCOUNT_TYPE: string,
    FIRST_NAME: string,
    MIDDLE_NAME: string,
    LAST_NAME: string,
    PHONE_NUMBER: string,
    EMAIL: string
  },
  ERRORS: string[]
  
}

class AccountRegistrationPage extends Component<{}, IAccountRegistrationState>{

  constructor(props: any){
    super(props)

    this.state = ({
      FORM: {
        USERNAME: "",
        PASSWORD: "",
        CONFIRM_PASSWORD: "",
        ACCOUNT_TYPE: "",
        FIRST_NAME: "",
        MIDDLE_NAME: "",
        LAST_NAME: "",
        PHONE_NUMBER: "",
        EMAIL: ""
      },
      ERRORS: []
    })    
  }

  render(): React.ReactNode {
      return(
        <Box flexDirection="row" flexWrap="wrap" display="flex" justifyContent='center' className={'wrapper'}>
          <Box m={1} className={`${styles.accountRegistrationPage}`} height='fit-content'>
            <header className={'padding1015'} style={{textAlign:'center'}}>
              <Typography variant="h4">Register account</Typography>
              <Typography variant="subtitle2">Fill out details to register.</Typography>
            </header>

            <div style={{textAlign: 'center'}} className={'padding1015'}>
              {this.state.ERRORS}
            </div>

            <Box flexDirection="row" flexWrap="wrap" display="flex" >
              <Box width="50%">
                <header className={'padding1015'} style={{textAlign:'center'}}>
                  <Typography variant="h6">Account details</Typography>
                </header>
                
                <div className={'padding1015'}>

                  <TextField name='USERNAME' id='USERNAME' value={this.state.FORM.USERNAME} label="Username" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='PASSWORD' id='PASSWORD' value={this.state.FORM.PASSWORD} label="Password" type="password" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='CONFIRM_PASSWORD' id='CONFIRM_PASSWORD' value={this.state.FORM.CONFIRM_PASSWORD} label="Confirm password" type="password" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <FormControl fullWidth>
                    <InputLabel id='ACCOUNT_TYPE_LABLE'>Account type</InputLabel>
                    <Select labelId='ACCOUNT_TYPE_LABLE' id='ACCOUNT_TYPE' name='ACCOUNT_TYPE' value={this.state.FORM.ACCOUNT_TYPE} onChange={(e) => {this.handleChanges(e)}} label="Account type">
                      <MenuItem value="0">None</MenuItem>
                      <MenuItem value="1">Student</MenuItem>
                      <MenuItem value="2">Tutor</MenuItem> 
                    </Select>
                  </FormControl>
                  
                </div>

              </Box>
              <Box width="50%">
                <header className={'padding1015'} style={{textAlign:'center'}}>
                  <Typography variant="h6">Personal details</Typography>
                </header>
                
                <div className={'padding1015'}>
                  <TextField name='FIRST_NAME' id='FIRST_NAMER' value={this.state.FORM.FIRST_NAME} label="First name" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='MIDDLE_NAME' id='MIDDLE_NAMER' value={this.state.FORM.MIDDLE_NAME} label="Middle name" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='LAST_NAME' id='LAST_NAME' value={this.state.FORM.LAST_NAME} label="Last name" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='PHONE_NUMBER' id='PHONE_NUMBER' value={this.state.FORM.PHONE_NUMBER} label="Phone number" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='EMAIL' id='EMAIL' value={this.state.FORM.EMAIL} label="E-Mail" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>
                  
                </div>
              </Box>

            </Box>

            <div style={{textAlign:'right'}}>
              <Button variant="contained" color="primary" onClick={() => this.registerAccount()}> Register </Button>            
            </div>
            <div style={{textAlign:'right', marginTop:'0.25rem'}}>
              <Button color="primary" href='/'> Already got account? Sign in. </Button>            
            </div>
          </Box>
        </Box>
      )
  }

  handleChanges(e: React.ChangeEvent | SelectChangeEvent){
    let field = e.target as HTMLInputElement

    this.setState({
      ... this.state,
      FORM: {
        ... this.state.FORM,
        [field.name]: field.value
      }
      
    })
  }

  async registerAccount(){
    fetch('/v1/account/register', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      }, 
      body: JSON.stringify(this.state.FORM)
    }).then(res => {
      switch(res.status){
        case 201:
          this.setState({
            ... this.state,
            ERRORS: [
              ... this.state.ERRORS,
              "Account created successfully."
            ]
          })
          break
        case 400:
          break
      }
    })
  }
  
}

export default AccountRegistrationPage

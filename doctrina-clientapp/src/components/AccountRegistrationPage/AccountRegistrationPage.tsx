import { Button, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { Component, FC } from 'react';
import IFormField from '../../core/IFormField';
import styles from './AccountRegistrationPage.module.scss';

interface IAccountRegistrationState{
  USERNAME: IFormField,
  PASSWORD: IFormField,
  CONFIRM_PASSWORD: IFormField,
  FIRST_NAME: IFormField,
  MIDDLE_NAME: IFormField,
  LAST_NAME: IFormField,
  PHONE_NUMBER: IFormField
  EMAIL: IFormField,
  ERRORS?: string[]
}

class AccountRegistrationPage extends Component<{}, IAccountRegistrationState>{

  constructor(props: any){
    super(props)

    this.state = {
      USERNAME: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      },
      PASSWORD: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      },
      CONFIRM_PASSWORD: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      },
      FIRST_NAME: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      },
      MIDDLE_NAME: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      },
      LAST_NAME: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      },
      PHONE_NUMBER: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      },
      EMAIL: {
        VALUE: "",
        IS_VALID: true,
        IS_TOUCHED: false,
        ERROR: ""        
      }

    }
  }

  render(): React.ReactNode {
      return(
        <Box flexDirection="row" flexWrap="wrap" display="flex" justifyContent='center' className={'wrapper'}>
          <Box m={1} className={`${styles.accountRegistrationPage}`} height='fit-content'>
            <header className={'padding1015'}>
              <Typography variant="h4">Register account</Typography>
              <Typography variant="subtitle2">Fill out details to register.</Typography>
            </header>

            <div className={'padding1015'}>
              <TextField
                name="USERNAME"
                helperText={this.state.USERNAME.ERROR}
                label="Username" 
                variant="outlined" 
                error = {!this.state.USERNAME.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />

              <TextField
                name="PASSWORD"
                type="password"
                helperText={this.state.PASSWORD.ERROR}
                label="Password" 
                variant="outlined" 
                error = {!this.state.PASSWORD.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />

              <TextField
                name="CONFIRM_PASSWORD"
                type="password"
                helperText={this.state.CONFIRM_PASSWORD.ERROR}
                label="Confirm password" 
                variant="outlined" 
                error = {!this.state.CONFIRM_PASSWORD.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />

              <TextField
                name="FIRST_NAME"
                helperText={this.state.FIRST_NAME.ERROR}
                label="First name" 
                variant="outlined" 
                error = {!this.state.FIRST_NAME.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />

              <TextField
                name="MIDDLE_NAME"
                helperText={this.state.MIDDLE_NAME.ERROR}
                label="Middle name" 
                variant="outlined" 
                error = {!this.state.MIDDLE_NAME.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />


              <TextField
                name="LAST_NAME"
                helperText={this.state.LAST_NAME.ERROR}
                label="Last name" 
                variant="outlined" 
                error = {!this.state.LAST_NAME.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />

              <TextField
                name="PHONE_NUMBER"
                helperText={this.state.PHONE_NUMBER.ERROR}
                label="Phone number" 
                variant="outlined" 
                error = {!this.state.PHONE_NUMBER.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />

              <TextField
                name="EMAIL"
                helperText={this.state.EMAIL.ERROR}
                label="E-Mail" 
                variant="outlined" 
                error = {!this.state.EMAIL.IS_VALID}
                style={{width:'100%', marginBottom:'1rem'}}
                onChange={(e) => {                
                  // this.handleChanges(e)
                }}
              />

              <div style={{textAlign:'right'}}>
                <Button variant="contained" color="primary"> Log in </Button>            
              </div>

            </div>
          </Box>
        </Box>
      )
  }
}

export default AccountRegistrationPage

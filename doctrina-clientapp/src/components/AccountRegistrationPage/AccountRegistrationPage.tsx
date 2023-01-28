import { TextFields } from '@mui/icons-material';
import { Button, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { ChangeEvent, Component, FC } from 'react';
import IFormField, { IForm, validateFromField } from '../../core/IFormField';
import styles from './AccountRegistrationPage.module.scss';

interface IAccountRegistrationState{
  USERNAME: string
  PASSWORD: string
  CONFIRM_PASSWORD: string,
  ACCOUNT_TYPE: string,
  FIRST_NAME: string,
  MIDDLE_NAME: string,
  LAST_NAME: string,
  PHONE_NUMBER: string,
  EMAIL: string
}

class AccountRegistrationPage extends Component<{}, IAccountRegistrationState>{

  constructor(props: any){
    super(props)

    this.state = ({
      USERNAME: "",
      PASSWORD: "",
      CONFIRM_PASSWORD: "",
      ACCOUNT_TYPE: "",
      FIRST_NAME: "",
      MIDDLE_NAME: "",
      LAST_NAME: "",
      PHONE_NUMBER: "",
      EMAIL: ""
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

            <Box flexDirection="row" flexWrap="wrap" display="flex" >
              <Box width="50%">
                <header className={'padding1015'} style={{textAlign:'center'}}>
                  <Typography variant="h6">Account details</Typography>
                </header>
                
                <div className={'padding1015'}>

                  <TextField name='USERNAME' id='USERNAME' value={this.state.USERNAME} label="Username" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='PASSWORD' id='PASSWORD' value={this.state.PASSWORD} label="Password" type="password" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='CONFIRM_PASSWORD' id='CONFIRM_PASSWORD' value={this.state.CONFIRM_PASSWORD} label="Confirm password" type="password" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <FormControl fullWidth>
                    <InputLabel id='ACCOUNT_TYPE_LABLE'>Account type</InputLabel>
                    <Select labelId='ACCOUNT_TYPE_LABLE' id='ACCOUNT_TYPE' name='ACCOUNT_TYPE' value={this.state.ACCOUNT_TYPE} onChange={(e) => {this.handleChanges(e)}} label="Account type">
                      <MenuItem value="none">None</MenuItem>
                      <MenuItem value="student">Student</MenuItem>
                      <MenuItem value="tutor">Tutor</MenuItem> 
                    </Select>
                  </FormControl>
                  
                </div>

              </Box>
              <Box width="50%">
                <header className={'padding1015'} style={{textAlign:'center'}}>
                  <Typography variant="h6">Personal details</Typography>
                </header>
                
                <div className={'padding1015'}>
                  <TextField name='FIRST_NAME' id='FIRST_NAMER' value={this.state.FIRST_NAME} label="First name" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='MIDDLE_NAME' id='MIDDLE_NAMER' value={this.state.MIDDLE_NAME} label="Middle name" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='LAST_NAME' id='LAST_NAME' value={this.state.LAST_NAME} label="Last name" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='PHONE_NUMBER' id='PHONE_NUMBER' value={this.state.PHONE_NUMBER} label="Phone number" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>

                  <TextField name='EMAIL' id='EMAIL' value={this.state.EMAIL} label="E-Mail" fullWidth onChange={(e) => {this.handleChanges(e)}} style={{marginBottom:'0.75rem'}}>
                  </TextField>
                  
                </div>
              </Box>

            </Box>

            <div style={{textAlign:'right'}}>
              <Button variant="contained" color="primary"> Register </Button>            
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
      [field.name]: field.value
    })
  }
  
}

export default AccountRegistrationPage

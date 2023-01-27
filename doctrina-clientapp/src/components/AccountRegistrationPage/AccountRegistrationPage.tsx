import { TextFields } from '@mui/icons-material';
import { Button, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { ChangeEvent, Component, FC } from 'react';
import IFormField, { IForm, validateFromField } from '../../core/IFormField';
import styles from './AccountRegistrationPage.module.scss';

interface IAccountRegistrationState{
  FORM: IForm
}

class AccountRegistrationPage extends Component<{}, IAccountRegistrationState>{

  constructor(props: any){
    super(props)

    this.state = {
      FORM: {
        FORM_FIELDS: [
          {
             NAME: "USERNAME",
             ID: "USERNAME",
             LABEL: "Username",
             FORM_FIELD: TextField,
             TYPE: "text",
             IS_VALID: true,
             IS_TOUCHED: false,
             VALUE: "",           
             VALIDATIONS: [{
              REGEX: "[A-Z]",
              ERROR_MESSAGE: "Username is valid."
              
             }]  
          },

          {
            NAME: "PASSWORD",
            ID: "PASSWORD",
            LABEL: "Password",
            FORM_FIELD: TextField,
            TYPE: "password",
            IS_VALID: true,
            IS_TOUCHED: false,
            VALUE: "",           
            VALIDATIONS: [{
             REGEX: "[A-Z]",
             ERROR_MESSAGE: "Password is valid."
             
            }]  
         }
        ]
      }
    }

    // this.state = {
    //   USERNAME: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: "",        
    //     VALIDATIONS: [{
    //       REGEX: "[A-Z]",
    //       ERROR_MESSAGE: "Username is mandatory."
    //     }]
    //   },
    //   PASSWORD: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""        
    //   },
    //   CONFIRM_PASSWORD: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""        
    //   },
    //   ACCOUNT_TYPE: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""
    //   },
    //   FIRST_NAME: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""        
    //   },
    //   MIDDLE_NAME: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""        
    //   },
    //   LAST_NAME: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""        
    //   },
    //   PHONE_NUMBER: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""        
    //   },
    //   EMAIL: {
    //     VALUE: "",
    //     IS_VALID: true,
    //     IS_TOUCHED: false,
    //     ERROR: ""        
    //   }

    // }
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

                  {this.state.FORM.FORM_FIELDS.map(field => {
                    return(
                      <field.FORM_FIELD 
                        name={field.NAME} 
                        id={field.ID} 
                        label={field.LABEL} 
                        type={field.TYPE}
                        style={{width:'100%', marginBottom: '0.75rem'}} 
                        error = {!field.IS_VALID} 
                        helperText={field.ERROR} 
                        onChange={(e: ChangeEvent) => this.handleChanges(e)}>
                      </field.FORM_FIELD>
                    )
                  })}
                  
                </div>

              </Box>
              <Box width="50%">
                <header className={'padding1015'} style={{textAlign:'center'}}>
                  <Typography variant="h6">Personal details</Typography>
                </header>
                
              </Box>

            </Box>

            <div style={{textAlign:'right'}}>
              <Button variant="contained" color="primary" onClick={() => {this.validateForm()}}> Register </Button>            
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

    let fieldState = this.state.FORM.FORM_FIELDS.find((field) => {
      return field.NAME === field.NAME ? field : undefined
    })

    if(fieldState !== undefined){
        fieldState.VALUE = field.value
        validateFromField(fieldState)

        this.setState({
          ... this.state,
          [field.name]: fieldState
        })
    }
    
  }

  validateForm(){

    this.state.FORM.FORM_FIELDS.map((field, index) => {
      debugger
      validateFromField(field)

      this.setState({
        ... this.setState,
        FORM: {
          FORM_FIELDS:[            
            ... this.state.FORM.FORM_FIELDS          
          ]
        }
      })
    })

  }
  
}

export default AccountRegistrationPage

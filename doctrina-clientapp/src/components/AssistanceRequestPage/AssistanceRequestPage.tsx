import { Button, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { FC, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import styles from './AssistanceRequestPage.module.scss';
import axios from 'axios'
import { useAtomValue } from 'jotai';
import { userAtom } from '../../core/AtomsConfig';

interface AssistanceRequestForm{
  DETAILS?: string,
  REQUEST_CATEGORY: string,
  EDUCATION_LEVEL: string
}

const AssistanceRequestPage: React.FC = () => {

  const navigate = useNavigate()
  const user = useAtomValue(userAtom)

  const [assistanceRequestForm, setAssistanceRequestForm] = useState<AssistanceRequestForm>({
    DETAILS: "",
    REQUEST_CATEGORY: "",
    EDUCATION_LEVEL: ""
  })

  return (
    <Box flexDirection="row" flexWrap="wrap" display="flex" justifyContent='center' className={'wrapper'}>
      <Box m={1} className={`${styles.assistanceRequestPage}`} height='fit-content'>
        <header className={'padding1015'} style={{textAlign:'center'}}>
          <Typography variant="h4">Assistance request</Typography>
          <Typography variant="subtitle2">Fill out assistance request details.</Typography>
        </header>

        <div className={'padding1015'}>
          <TextField multiline label="Details" name='DETAILS' value={assistanceRequestForm.DETAILS} fullWidth rows={4} style={{marginBottom: '0.75rem'}} onChange={(e) => handleChanges(e)}></TextField>

          <FormControl fullWidth style={{marginBottom: '0.75rem'}}>
            <InputLabel id='REQUEST_CATEGORIES_LABLE'>Request category</InputLabel>
            <Select label="Request category" name='REQUEST_CATEGORY' value={assistanceRequestForm.REQUEST_CATEGORY} onChange={(e) => handleChanges(e)}>
              <MenuItem value="0">None</MenuItem>
              <MenuItem value="1">Assistance help</MenuItem>
              <MenuItem value="2">Teaching</MenuItem>
              <MenuItem value="3">Study teaching</MenuItem>
              <MenuItem value="4">Advice</MenuItem>
            </Select>                
          </FormControl>

          <FormControl fullWidth>
            <InputLabel id='EDUCATION_LEVEL_LABLE'>Education level</InputLabel>
            <Select label="Education level" name='EDUCATION_LEVEL' value={assistanceRequestForm.EDUCATION_LEVEL} onChange={(e) => handleChanges(e)}>
              <MenuItem value="0">None</MenuItem>
              <MenuItem value="1">High school</MenuItem>
              <MenuItem value="2">Diploma</MenuItem>
              <MenuItem value="3">Post-grad certificate</MenuItem>
              <MenuItem value="4">Masters</MenuItem>
              <MenuItem value="5">Doctrate</MenuItem>
            </Select>                
          </FormControl>

          <div style={{textAlign:'right'}}>
            <Button variant="contained" color="primary" onClick={() => saveAssistanceRequest()}> Request </Button>            
          </div>
        </div>
    </Box>
    </Box>
  )

  function handleChanges(e: React.ChangeEvent | SelectChangeEvent){

    let field = e.target as HTMLInputElement

    setAssistanceRequestForm({
      ... assistanceRequestForm,
      [field.name]: field.value
    })
  }

  function saveAssistanceRequest(){
    fetch("/v1/assistance-request/register", {
      method: 'POST', 
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${user.ACCESS_TOKEN}`
      },
      body: JSON.stringify(assistanceRequestForm)
    }).then(res => {
      switch(res.status){
        case 201:
          navigate("/home")
          break
        case 400:
          break;
      }
    })
  }
}

export default AssistanceRequestPage;

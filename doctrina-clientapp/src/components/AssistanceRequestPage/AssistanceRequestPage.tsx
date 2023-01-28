import { Button, FormControl, InputLabel, MenuItem, Select, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';
import React, { FC } from 'react';
import styles from './AssistanceRequestPage.module.scss';

interface AssistanceRequestPageProps {}

class AssistanceRequestPage extends React.Component{

  constructor(props: any){
    super(props)
  }

  render(): React.ReactNode {
      return(
        <Box flexDirection="row" flexWrap="wrap" display="flex" justifyContent='center' className={'wrapper'}>
          <Box m={1} className={`${styles.assistanceRequestPage}`} height='fit-content'>
            <header className={'padding1015'} style={{textAlign:'center'}}>
              <Typography variant="h4">Assistance request</Typography>
              <Typography variant="subtitle2">Fill out assistance request details.</Typography>
            </header>

            <div className={'padding1015'}>
              <TextField multiline label="Details" fullWidth rows={4} style={{marginBottom: '0.75rem'}}></TextField>
              <FormControl fullWidth style={{marginBottom: '0.75rem'}}>
                <InputLabel id='REQUEST_CATEGORIES_LABLE'>Request category</InputLabel>
                <Select label="Request category">
                  <MenuItem value="0">None</MenuItem>
                  <MenuItem value="1">Assistance help</MenuItem>
                  <MenuItem value="2">Teaching</MenuItem>
                  <MenuItem value="3">Study teaching</MenuItem>
                  <MenuItem value="4">Advice</MenuItem>
                </Select>                
              </FormControl>

              <FormControl fullWidth>
                <InputLabel id='EDUCATION_LEVEL_LABLE'>Education level</InputLabel>
                <Select label="Education level">
                  <MenuItem value="0">None</MenuItem>
                  <MenuItem value="1">High school</MenuItem>
                  <MenuItem value="2">Diploma</MenuItem>
                  <MenuItem value="3">Post-grad certificate</MenuItem>
                  <MenuItem value="4">Masters</MenuItem>
                  <MenuItem value="5">Doctrate</MenuItem>
                </Select>                
              </FormControl>
            </div>

            <div style={{textAlign:'right'}}>
              <Button variant="contained" color="primary"> Request </Button>            
            </div>
          </Box>          
        </Box>
      )
  }
}

export default AssistanceRequestPage;

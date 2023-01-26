import React from 'react';
import logo from './logo.svg';
import './App.scss';
import { Button, Card, InputAdornment, TextField, Typography } from '@mui/material';
import { Box } from '@mui/system';

function App() {
  return (
    <div className="centralize welcomeCard">
      {RegistrationCard()}
    </div>

    
  )
}

function RegistrationCard(){
  return (
    <Box flexDirection="row" flexWrap="wrap" display="flex" justifyContent='center' className={'wrapper'}>
      <Box m={1} className={"loginCard"} height='fit-content'>
        <header className={"padding1015"}>
          <Typography variant="h4">Welcome</Typography>
          <Typography variant="subtitle2">Login to continue to services</Typography>
        </header>

        <div style={{padding:'20px 15px'}}>
        <TextField id="outlined-basic" 
                     helperText="test" 
                     label="Username" 
                     variant="outlined" 
                     style={{width:'100%', marginBottom:'0.75rem'}}
                     InputProps={{
                       startAdornment: (
                         <InputAdornment position="start">
                           {/* <FontAwesomeIcon icon={faUser} style={{fontSize:'21px'}}/> */}
                         </InputAdornment>
                       )
                     }} />
        
        <TextField id="outlined-basic"                      
                     helperText="Test"
                     type="password"
                     label="Password" 
                     variant="outlined" 
                     style={{width:'100%'}}
                     InputProps={{
                       startAdornment: (
                         <InputAdornment position="start">
                           {/* <FontAwesomeIcon icon={faKey} style={{fontSize:'21px'}}/> */}
                         </InputAdornment>
                       ),
                       endAdornment: (
                         <InputAdornment position="end">
                           {/* <FontAwesomeIcon icon={faEyeSlash} style={{fontSize:'21px'}} className={'cursor-pointer'}/> */}
                         </InputAdornment>
                       )
                     }} />
        
          <div style={{textAlign:'right'}}>
            <Button variant="contained" color="primary"> Log in </Button>            
          </div>
        
        </div>

        

        <div style={{padding:'20px 15px', border: '1px solid #ccc', cursor:'pointer'}}>
          <header className={"padding1015"}>
            <Typography variant="h5">Not yet registered?</Typography>
            <Typography variant="subtitle2">Click register to continue.</Typography>
          </header>

          <div style={{textAlign:'right'}}>
            <Button variant="contained" color="primary"> Register </Button>            
          </div>
        </div>
      </Box>
    </Box>
  )
}

function SignInCard(){
  return (
    <Card className='padding2030 shadow-1 '>
        <Typography variant='h5'>Register</Typography>
    </Card>
  )
}

export default App;

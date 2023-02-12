import { Button, Card, CardContent, CardHeader, Typography } from '@mui/material';
import { Box } from '@mui/system';
import { useAtom } from 'jotai';
import { RESET } from 'jotai/utils';
import React, { FC, useEffect, useState } from 'react';
import { useNavigate } from 'react-router';
import { userAtom } from '../../core/AtomsConfig';
import styles from './HomePage.module.scss';

interface AssistanceRequest{
  DETAILS: string,
  EDUCATION_LEVEL: string,
  CATEGORY: string,
  CREATED_ON: string
}

const HomePage: React.FC = () => {

  const navigate = useNavigate()
  const [user, setUser] = useAtom(userAtom)
  const [assistanceRequests, setAssistanceRequests] = useState<AssistanceRequest[]>([])

  const logout = () => {
    setUser(RESET)
    navigate("/")
  }

  const loadAssistanceRequest = () =>{
    fetch("/v1/assistance-request/fetch", {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${user.ACCESS_TOKEN}`
      }
    }).then(res => {
      switch(res.status){
        case 200:{

          res.json().then(data => {
            debugger
            setAssistanceRequests(data)
          })

          break
        }
        case 400:
          break
      }
    })
  }

  useEffect(() => {
    loadAssistanceRequest()
  })

  return (
    <div>
      <Button color='primary' variant='contained' href='/assistance-request'>Request assistance</Button>
      <Button color='primary' variant='contained' onClick={() => logout()}>Logout</Button>


      <Box display="flex" flexDirection='row' className='padding2030'>
        {
          assistanceRequests.map(assistanceRequest =>{
            return (
              <Box m={1}>
                <Card style={{width:'420px'}} className='padding1015'>
                  <CardHeader 
                    title= {assistanceRequest.CATEGORY}
                    subheader = {assistanceRequest.EDUCATION_LEVEL}
                  />
                  
                  <CardContent>
                    <Typography variant='body2'>{assistanceRequest.DETAILS}</Typography>
                  </CardContent>
                  
                </Card>
              </Box>
              
            )
          })
        }
      </Box>
    </div>
  )
}

export default HomePage;

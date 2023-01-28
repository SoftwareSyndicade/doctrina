import { Button } from '@mui/material';
import React, { FC } from 'react';
import styles from './HomePage.module.scss';

interface HomePageProps {}

class HomePage extends React.Component{
  constructor(props: any){
    super(props)
  }

  render(): React.ReactNode {
      return(
        <div>
          <Button color='primary' variant='contained' href='/assistance-request'>Request assistance</Button>
        </div>
      )
  }
}

export default HomePage;

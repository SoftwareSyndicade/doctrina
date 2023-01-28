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
          Home page
        </div>
      )
  }
}

export default HomePage;

import React, { FC } from 'react';
import styles from './AssistanceRequestPage.module.scss';

interface AssistanceRequestPageProps {}

class AssistanceRequestPage extends React.Component{

  constructor(props: any){
    super(props)
  }

  render(): React.ReactNode {
      return(
        <div>
          Assistance request
        </div>
      )
  }
}

export default AssistanceRequestPage;

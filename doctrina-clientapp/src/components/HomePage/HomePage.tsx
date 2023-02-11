import { Button } from '@mui/material';
import { useAtom } from 'jotai';
import { RESET } from 'jotai/utils';
import React, { FC } from 'react';
import { userAtom } from '../../core/AtomsConfig';
import styles from './HomePage.module.scss';

const HomePage: React.FC = () => {

  const [user, setUser] = useAtom(userAtom)

  const logout = () => {
    setUser(RESET)
  }

  return (
    <div>
      <Button color='primary' variant='contained' href='/assistance-request'>Request assistance</Button>
      <Button color='primary' variant='contained' onClick={() => logout()}>Logout</Button>
    </div>
  )
}

export default HomePage;

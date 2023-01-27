import React, { lazy, Suspense } from 'react';

const LazyAccountRegistrationPage = lazy(() => import('./AccountRegistrationPage'));

const AccountRegistrationPage = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazyAccountRegistrationPage {...props} />
  </Suspense>
);

export default AccountRegistrationPage;

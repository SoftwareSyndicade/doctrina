import React, { lazy, Suspense } from 'react';

const LazyAssistanceRequestPage = lazy(() => import('./AssistanceRequestPage'));

const AssistanceRequestPage = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazyAssistanceRequestPage {...props} />
  </Suspense>
);

export default AssistanceRequestPage;

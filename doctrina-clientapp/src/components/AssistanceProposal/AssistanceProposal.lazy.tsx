import React, { lazy, Suspense } from 'react';

const LazyAssistanceProposal = lazy(() => import('./AssistanceProposal'));

const AssistanceProposal = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazyAssistanceProposal {...props} />
  </Suspense>
);

export default AssistanceProposal;

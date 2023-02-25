import React, { FC } from 'react';
import styles from './AssistanceProposal.module.scss';

interface AssistanceProposalProps {}

const AssistanceProposal: FC<AssistanceProposalProps> = () => (
  <div className={styles.AssistanceProposal}>
    AssistanceProposal Component
  </div>
);

export default AssistanceProposal;

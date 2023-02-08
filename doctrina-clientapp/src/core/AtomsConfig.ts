import { atom } from 'jotai'
import Account from './auth/models/Account'

export const userAtom = atom<Account>({
    ACCESS_TOKEN: '',
    ACCOUN_TYPE: '',
    ID: '',
    NAME: '',
    IS_AUTHENTICATED: false
})
import { atom } from 'jotai'
import { atomWithStorage } from 'jotai/utils'
import Account from './auth/models/Account'

const accountInit = ():Account => {
    const storedUser = localStorage.getItem("ACCOUNT")

    if(storedUser != null){
        return JSON.parse(storedUser)
    }

    return {
        ACCESS_TOKEN: '',
        ACCOUN_TYPE: '',
        ID: '',
        NAME: '',
        IS_AUTHENTICATED: false
    }
} 

export const userAtom = atomWithStorage<Account>("ACCOUNT", accountInit())

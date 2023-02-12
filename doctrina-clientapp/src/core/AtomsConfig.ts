import { atom } from 'jotai'
import jwt_decode, { JwtPayload } from "jwt-decode";
import { atomWithStorage } from 'jotai/utils'
import Account from './auth/models/Account'

const accountInit = ():Account => {
    const storedUser = localStorage.getItem("ACCOUNT")

    let userAccount: Account = {
        ACCESS_TOKEN: '',
        ACCOUN_TYPE: '',
        ID: '',
        NAME: '',
        IS_AUTHENTICATED: false
    }

    if(storedUser != null){
        const ua:Account = JSON.parse(storedUser)
        let jwt = jwt_decode<JwtPayload>(ua.ACCESS_TOKEN)

        if(jwt.exp !== undefined && (jwt.exp * 1000) > new Date().getSeconds())
            userAccount = JSON.parse(storedUser)
    }

    return userAccount
} 

export const userAtom = atomWithStorage<Account>("ACCOUNT", accountInit())

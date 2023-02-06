import { useEffect, useState } from "react"

interface Account {

}

const useAuth = (user: Account) =>{

    const [data, setData] = useState<Account>()
    const [isAuthenticated, setAuthenticated] = useState<boolean>(false)

    useEffect(() => {
        setData(user)
        setAuthenticated(true)
        localStorage.setItem("", data)
    })

    return { user, isAuthenticated }
}

export default useAuth
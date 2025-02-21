import React from "react"
import { Layout } from "antd"
import AppLayout from "../Fragments/Generic/AppLayout"

export interface LoginRegisterProps {
    child: React.ReactNode
    title: string
}
const LoginRegister: React.FC<LoginRegisterProps> = ({ child }) => {

    const LoginRegisterStyle: React.CSSProperties = {
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
    }



    return (

        <AppLayout>
            <Layout style={LoginRegisterStyle}>
                {child}
            </Layout>
        </AppLayout>
    )
}

export default LoginRegister
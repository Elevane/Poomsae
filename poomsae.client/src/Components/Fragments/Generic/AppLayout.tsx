import { Layout, theme } from "antd"
import React from "react"
const { useToken } = theme;

export interface AppLayoutProps {
    children: React.ReactNode
}

const AppLayout: React.FC<AppLayoutProps> = ({ children }) => {
    const { token } = useToken()
    return (
        <Layout className="app" style={{ minHeight: "100vh" }} >{children}</Layout>
    );
}

export default AppLayout
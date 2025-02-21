import { Layout } from "antd"
import React from "react"
import { Link } from "react-router"

const Footer: React.FC = () => {
    return (

        <Layout.Footer style={{
            textAlign: 'center', backgroundColor: "#001529", color: "white",
        }}>
            Poomsae &copy;{new Date().getFullYear()} Created by  <Link to="https://gitAccount.com/Elevane" target="_blank">AUBRY Bastien</Link>
        </Layout.Footer>)
}
export default Footer
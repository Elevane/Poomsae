import { Menu, MenuProps } from "antd";
import { Header } from "antd/es/layout/layout"
import Title from "antd/es/typography/Title"
import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router";


const HeaderFragment: React.FC = () => {
	const navigate = useNavigate()
	const location = useLocation()
	const [pageIndex, setPageIndex] = useState<string>("")
	const pages = ['hub', 'learn', 'account']
	const items1: MenuProps['items'] = pages.map((name,key) => ({
		key,
		label: `${String(name).charAt(0).toUpperCase() + String(name).slice(1)}`,
		onClick: (e) => {
			navigate(`/${name}`)
		}
	}));
	

	useEffect(() => {
		const page = location.pathname.split("/")
		console.log("page " + page[1])
		const pageindexString = pages.findIndex(p => p == page[1]);
		console.log("pageindexString " + pageindexString)
		setPageIndex(`${pageindexString}`)
	}, [])

	return (
		<Header style={{ display: 'flex', alignItems: 'center', justifyContent: "space-between" }}>
			<Title level={1} style={{ fontFamily: "Nunito, serif", color: "White" }}> Poomsae </Title>
			{pageIndex}
			<Menu
				theme="dark"
				mode="horizontal"
				selectedKeys={[pageIndex]}
				items={items1}
				style={{ flex: 1, display: 'flex', alignItems: 'center', justifyContent: "flex-start", marginLeft:"5vh" }}
			/>
		</Header>
	)
}

export default HeaderFragment
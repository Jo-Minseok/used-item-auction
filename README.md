# 💸 유즈옥션 (Used Items Auction)

<div align="center">
<img width="60%" src="https://github.com/Jo-Minseok/used-item-auction/assets/99482796/f8684c86-de39-4461-b8c5-d83e99c7b580"><br>
<a href="https://hits.seeyoufarm.com"><img width = "13%" src="https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2FJo-Minseok%2Fused-item-auction&count_bg=%23FFBB00&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false"/></a>
</div>

## CONTENTS

- [TEAM](#TEAM)
  - [Intro](#Intro)
- [PROJECT INFORMATION](#PROJECT-INFORMATION)
  - [Mean](#Mean)
  - [Goal](#Goal)
  - [Explain](#Explain)
- [STACKS](#STACKS)
  - [Development](#Development)
  - [Database](#Database)
  - [Language](#Language)
  - [Function](#Function)

## TEAM

### Intro

<table align="center">
    <th>이름</th>
    <th>Github</th>
    <tr>
        <td>조민석 (2학년)</td>
        <td><a href="https://github.com/Jo-Minseok">@Jo-Minseok</a></td>
    </tr>
</table>

## PROJECT INFORMATION

> 동의대학교 2022학년도 비주얼 프로그래밍 개인 프로젝트 </br>
> PERIOD: 2022.11.04 ~ 2022.12.08 (1 Month)</br>

### Mean

📃 유즈 아이템은 '중고 물품', 옥션은 '경매'를 합쳐, 유즈 아이템 옥션이라고 프로젝트 명을 작명하였다.

### Goal

🥇 차후 조금 더 개발 역량을 늘렸을 때, 웹 소켓, 서버 등을 구축하여 진짜 사업을 할 수 있도록 하는 것을 목표로 한다. 중고 물품 거래는 구매자를 중점으로 진행 되는 데, 본 프로그램은 경매 방식을 이용하여 판매자의 중점(최대한 비싼 가격)을 생각하고자 만들었다.

### Explain

📃 유저 모드에서는 로그인, 회원가입, 게시글 등록, 포인트 충전/출금, 경매 참여, 경매 입찰 확인, 경매 낙찰, 주문 조회를 할 수 있는 기능을 포함하여 중고 물품 경매를 할 수 있도록 하였다. 관리자 모드에서는 적절하지 않은 게시글 삭제, 카테고리 등록/삭제/추가할 수 있으며, 사용자 정보 수정이 가능하다.

## STACKS

### Development

<img src="https://img.shields.io/badge/Visual%20Studio%20Community-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white">

### Database

<img src="https://img.shields.io/badge/mysql-4479A1?style=for-the-badge&logo=mysql&logoColor=white">

### Language

<img src="https://img.shields.io/badge/C%23%20Winform-512BD4?style=for-the-badge&logo=csharp&logoColor=white">

### Function

<details>
    <summary><strong>💡 게시글 등록</strong></summary>
    <ul>
        <li>물품 사진, 설명, 마감일, 시작 금액, 금액 단위를 설정할 수 있다.</li>
    </ul>
</details>
<details>
    <summary><strong>💡 물품 경매</strong></summary>
    <ul>
        <li>현재 최고가 금액보다 + [금액] 만큼 최고가를 갱신하여 경매에 참가할 수 있다.</li>
        <li>판매자는 원하는 금액에 대해 최고가로 낙찰할 수 있다.</li>
        <li>낙찰 시 최고가 낙찰자 유저의 주소를 확인할 수 있으며, 배송을 진행할 수 있다.</li>
        <li>현재 내가 참가한 경매들을 한 번에 조회할 수 있고, 경매 최고가에서 밀려났을 경우 기록을 남긴다.</li>
    </ul>
</details>
<details>
    <summary><strong>💡 포인트 충전, 출금</strong></summary>
    <ul>
        <li>포인트 충전이 가능하다.</li>
        <li>경매를 포인트로 참여할 수 있다.</li>
        <li>포인트를 출금할 수 있다.</li>
    </ul>
</details>

# ProjectM

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/76cb49f0-bd74-4e82-b981-bda3d248c41c)


## **프로젝트 소개**

- **로그라이크 형식의 TPS 슈팅 게임 제작**
- [**비트윈 메리 캐릭터](https://merrybetween.com/board/story/8/)를 모티브로 직접 3d 모델링**
- **유니티 타임라인으로 다양한 영상 연출**

## 목차

1. [**메인 씬**](![image](https://github.com/akffoddl5/ProjectM/assets/44525847/a09dca3c-b8e2-427b-8b67-c2f44dda586f)
)
    
    **1-1. 게임시작 타임라인**
    
    **1-2. 아이템 도감**
    
    **1-3. 게임 종료 버튼**
    
2. **게임 씬**
    
    **2-1. 게임 옵션 설정**
    
3. **아이템**
    
    **3-1. 아이템 스폰**
    
    **3-2. 아이템 획득**
    
4. **스폰 시스템**
5. **캐릭터 조작**
    
    **5-1. 캐릭터 모델링 및 리깅**
    
    **5-2. 귀 조인트**
    
    **5-3. FSM**
    
    **5-4. 에임 조준**
    
    **5-5 총알 발사**
    
6. **적 구현**
    
    **6-1. 해골**
    
    **6-2. 상어**
    
    **6-3. 미라**
    
7. **GAME OVER**
8. **CLEAR**

### **1. 메인 씬**

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/d643c375-6584-4f66-93f0-960236ef0f0c)


- 닭, 병아리들을 랜덤으로 애니메이션을 재생하며 화면에 노출
- 검은 복면을 쓴 캐릭터는 춤을 추며 대기.

**1-1. 게임시작 타임라인**

- 게임 시작 버튼 누를시 시키고 카메라 전환되며 타임라인 시작
- UI가 꺼지고 하늘에서 주인공이 떨어지는 장면을 CInemachine 을 이용해 연출
- 메리가 땅에 추락하고 닭, 병아리, 검은복면(이하 닌자) 는 추락 지점으로부터 도망

https://youtu.be/ImRZiRvXDnY

**1-2. 아이템 도감**

- 아이템 버튼 클릭시 월드에 있는 캔버스 도감 정보 노출. (시네머신 전환)
- 아이템 획득시 PlayerPrefabs 에 정보 저장하여 도감에 노출되도록 작업

https://youtu.be/Su1nR8fauPo

**1-3. 게임 종료 버튼**

- Application 종료

### 2**. 게임 씬**

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/997c4841-dba9-4603-bfce-29458358118e)


- 현재 체력, 현재 스테이지, 아이템 현황 등 표시.
- MENU 버튼으로 게임 옵션을 조절.

**2-1. 게임 옵션 설정**

- 배경음악, 효과음 조절 옵션

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/45e9466a-0be6-40da-a15a-4a592b6da5a6)


- 감도 조절 옵션

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/05bc9c26-fb9e-4226-8d17-f2bfcd77cb4f)


### 3**. 아이템**

아이템 장착시 기본 능력치가 증가하고 외형 변경

- 빨간 안경 : 치명타 확률 증가
- 천사 날개 : 점프 가능 횟수 증가
- 악마 날개 : 대쉬 거리 증가
- 벨트 : 공격력 증가
- 낡은 구두 : 이동속도 증가
- 파티용 모자 : 최대체력 증가

장착시 외형변경(벨트, 악마 날개 장착시 모습)

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/a3a5f63e-75cd-47d1-b1ab-51b5a27671f8)


**3-1. 아이템 스폰**

- 스폰 되는 랜덤한 적들 중 랜덤으로 아이템이 드랍되도록 작업

**3-2. 아이템 획득**

- 드랍된 아이템 획득 시 하단 인벤토리로 회전하면 들어가도록 연출
- 아직 획득하지 않은 아이템이라면 이펙트와 함께 외형변화

### 4**. 스폰 시스템**

- 1분마다 STAGE가 올라가며 적들이 스폰(우상단 게이지 참고)
- 스폰되는 적들중에 하나는 랜덤한 아이템을 소지하고 드랍
- 드랍된 아이템은 이펙트와 함께 회전하며 2D 캔버스로 들어오는 연출

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/e0d76fae-5935-4d11-bb7f-90f55c90986b)


### 5**. 캐릭터 조작**

**5-1. 캐릭터 모델링 및 리깅(블렌더)**

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/3c2e8840-2b67-4285-bcf8-b019ba6f07bf)


**5-2. 귀 조인트**

- 리깅된 귀 부분에 Character Joint로 물리 영향을 받아 펄럭이도록 작업
- 코루틴으로 일정 주기마다 귀를 움직이도록 작업

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/3b7648f0-5afb-41b0-bced-9d19aea964c1)


**5-3. FSM**

- 스테이트 머신으로 TPS 캐릭터 움직임 구현
- IDLE, 움직임, 대쉬, 점프, 조준 등 구현

**5-4. 에임 조준**

- 우클릭시 1인칭 조준 상태가 되며 시네머신 이동
- 카메라 컬링으로 1인칭시 캐릭터는 보이지 않도록 작업
- 조준시 크로스 헤어 활성화

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/edf174ce-828b-4204-a2bb-eac4c3ff3565)


**5-5. 총알 발사**

- 총알 발사 시 양쪽 권총에서 번갈아가며 발사(콤보 형식)
- 시네머신 VerticalAxis 를 조절하는 방식으로 반동 구현

### 6**. 적 구현**

- 기본적으로 Enemy 컴포넌트를 상속받도록 구현
- 적의 체력바는 카메라를 바라도록 구현

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/c209c9ea-6c6c-4eff-9c92-16d1001636e6)


**6-1. 해골**

- Nav Mesh로 플레이어를 추격
- 플레이어와의 거리에 따라 걷기, 뛰기, 공격 행동 결정
- 헤드로 공격받을 시 데미지 1.5배 판정

**6-2. 상어**

- 공중에서 스폰되는 오브젝트라 직접 플레이어를 추격
- 플레이어와 너무 가까워지면 거리를 벌리며 원거리 공격

**6-2. 미라**

- Nav Mesh로 플레이어를 추격
- 공격범위 안에 들어올시 차징 공격
- 공격 전 레이저로 범위 표시

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/6483eebc-7ddd-4962-a18b-be52a0612680)


### 7**. GAME OVER**

- 카메라 전환되고 캐릭터 포커스 맞추며 메인 씬으로 이동

![image](https://github.com/akffoddl5/ProjectM/assets/44525847/403e12ee-ef2f-405c-b13b-21e4232c2dbe)


### 7**. CLEAR**

- CLEAR 씬 타임 라인

https://youtu.be/LivWURikAcA

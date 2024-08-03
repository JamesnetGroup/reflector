# Reflector

WPF와 .NET의 고급 기술을 실험하고 적용하는 실용적인 학습 프로젝트

[![English](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![한국어](https://img.shields.io/badge/Language-한국어-red.svg)](README.ko.md)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Stars](https://img.shields.io/github/stars/jamesnet214/reflector.svg)](https://github.com/jamesnet214/reflector/stargazers)
[![Issues](https://img.shields.io/github/issues/jamesnet214/reflector.svg)](https://github.com/jamesnet214/reflector/issues)

## 프로젝트 개요

Reflector는 WPF 개발자들이 고급 기술을 실험하고 적용할 수 있는 실습 중심의 프로젝트입니다. 이 프로젝트를 통해 복잡한 WPF 애플리케이션 구조, 동적 어셈블리 분석, 그리고 고급 컨트롤 템플릿 설계 등을 직접 구현하고 심도 있게 학습할 수 있습니다.


<img src="https://github.com/user-attachments/assets/6f8ae2c5-dfdd-4118-b228-ebae32df6005" width="49.5%"/>
<img src="https://github.com/user-attachments/assets/1088c829-a33c-41c1-b912-6ce034779237" width="49.5%"/>

## 핵심 기술 및 구현 사항

#### 1. 프로젝트 구조화 및 모듈화
- [x] 의존성 주입을 활용한 느슨한 결합 구현
- [x] 프로젝트 분산화를 통한 유지보수성 향상
- [x] Prism 라이브러리를 활용한 모듈 기반 아키텍처 구현

#### 3. 리플렉션과 동적 어셈블리 분석
- [x] System.Reflection 네임스페이스를 활용한 런타임 타입 정보 접근
- [x] 동적 DLL 로딩 및 분석 기법 적용
- [x] 메타데이터를 활용한 클래스, 인터페이스, 메서드, 속성 등의 구조 파악

#### 4. 고급 WPF 컨트롤 및 템플릿 설계
- [x] CustomControl을 활용한 TreeView, ListBox 확장 구현
- [x] 복잡한 계층 구조를 위한 재귀적 ItemsPresenter 포함 ControlTemplate 설계
- [x] DataTemplate와 ControlTemplate의 고급 활용 기법

#### 5. MVVM 아키텍처 심화
- [x] 완전한 MVVM 패턴 구현 및 데이터 바인딩 최적화
- [x] Command 패턴과 INotifyPropertyChanged 인터페이스의 효과적 활용
- [x] ViewModel 간 통신을 위한 이벤트 어그리게이터 패턴 적용

#### 6. 성능 최적화 기법
- [x] 가상화(Virtualization) 기술을 활용한 대량 데이터 처리
- [x] 멀티스레딩을 통한 UI 응답성 향상
- [x] 메모리 누수 방지를 위한 약한 참조(Weak References) 활용

## 기술 스택

- .NET 8.0
- WPF (Windows Presentation Foundation)
- MVVM (Model-View-ViewModel) 패턴
- Prism Library
- Jamesnet.Wpf NuGet 패키지

## 시작하기

### 필요 조건

- Visual Studio 2022 이상
- .NET 8.0 SDK

### 설치 및 실행

#### 1. 리포지토리 클론:
```
git clone https://github.com/jamesnet214/reflector.git
```
#### 2. 솔루션 열기
- [x] Visual Studio
- [x] Visual Studio Code
- [x] Jetbrains Rider

#### 3. 빌드 및 실행
- [x] Windows 11 권장

## 사용 방법

1. 애플리케이션 실행
2. DLL 파일 선택 및 로드
3. 트리 뷰에서 원하는 항목 탐색
4. 선택된 항목의 상세 정보를 오른쪽 패널에서 확인

## 기여하기

프로젝트 개선에 기여하고 싶으시다면 Pull Request를 보내주세요. 모든 형태의 기여를 환영합니다!

## 라이선스

이 프로젝트는 MIT 라이선스 하에 배포됩니다. 자세한 내용은 [LICENSE](https://github.com/jamesnet214/reflector/blob/main/LICENSE) 파일을 참조하세요.

## 연락처

- 웹사이트: https://jamesnet.dev
- 이메일: james@jamesnet.dev, vickyqu115@hotmail.com

Reflector를 통해 WPF 개발의 고급 기술을 탐색하고 실제 프로젝트에 적용해보세요!

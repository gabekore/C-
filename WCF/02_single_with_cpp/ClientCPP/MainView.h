#pragma once

namespace ClientCPP {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::ServiceModel;
	using namespace Interface;
	using namespace System::Collections::Generic;

	/// <summary>
	/// MainView �̊T�v
	/// </summary>
	public ref class MainView : public System::Windows::Forms::Form
	{
	public:
		MainView(void)
		{
			InitializeComponent();
			//
			//TODO: �����ɃR���X�g���N�^�[ �R�[�h��ǉ����܂�
			//
		}

	protected:
		/// <summary>
		/// �g�p���̃��\�[�X�����ׂăN���[���A�b�v���܂��B
		/// </summary>
		~MainView()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  BtnHelloWorld;
	private: System::Windows::Forms::TextBox^  TxbLog;
	private: System::Windows::Forms::Button^  BtnCalcPlus;
	private: System::Windows::Forms::Button^  BtnCalcMinus;
	private: System::Windows::Forms::Button^  BtnUsetTuple;
	private: System::Windows::Forms::Button^  BtnOverLoad;
	private: System::Windows::Forms::Button^  BtnUseArray;





	private: System::Windows::Forms::Button^  BtnUseListClass;

	private: System::Windows::Forms::Button^  BtnUseClass;



	protected:

	protected:

	private:
		/// <summary>
		/// �K�v�ȃf�U�C�i�[�ϐ��ł��B
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// �f�U�C�i�[ �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�[�ŕύX���Ȃ��ł��������B
		/// </summary>
		void InitializeComponent(void)
		{
			this->BtnHelloWorld = (gcnew System::Windows::Forms::Button());
			this->TxbLog = (gcnew System::Windows::Forms::TextBox());
			this->BtnCalcPlus = (gcnew System::Windows::Forms::Button());
			this->BtnCalcMinus = (gcnew System::Windows::Forms::Button());
			this->BtnUsetTuple = (gcnew System::Windows::Forms::Button());
			this->BtnOverLoad = (gcnew System::Windows::Forms::Button());
			this->BtnUseArray = (gcnew System::Windows::Forms::Button());
			this->BtnUseListClass = (gcnew System::Windows::Forms::Button());
			this->BtnUseClass = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// BtnHelloWorld
			// 
			this->BtnHelloWorld->Location = System::Drawing::Point(12, 22);
			this->BtnHelloWorld->Name = L"BtnHelloWorld";
			this->BtnHelloWorld->Size = System::Drawing::Size(117, 36);
			this->BtnHelloWorld->TabIndex = 0;
			this->BtnHelloWorld->Text = L"HelloWorld";
			this->BtnHelloWorld->UseVisualStyleBackColor = true;
			this->BtnHelloWorld->Click += gcnew System::EventHandler(this, &MainView::BtnHelloWorld_Click);
			// 
			// TxbLog
			// 
			this->TxbLog->Location = System::Drawing::Point(12, 219);
			this->TxbLog->Multiline = true;
			this->TxbLog->Name = L"TxbLog";
			this->TxbLog->ScrollBars = System::Windows::Forms::ScrollBars::Both;
			this->TxbLog->Size = System::Drawing::Size(425, 248);
			this->TxbLog->TabIndex = 1;
			// 
			// BtnCalcPlus
			// 
			this->BtnCalcPlus->Location = System::Drawing::Point(12, 64);
			this->BtnCalcPlus->Name = L"BtnCalcPlus";
			this->BtnCalcPlus->Size = System::Drawing::Size(117, 36);
			this->BtnCalcPlus->TabIndex = 2;
			this->BtnCalcPlus->Text = L"CalcPlus";
			this->BtnCalcPlus->UseVisualStyleBackColor = true;
			this->BtnCalcPlus->Click += gcnew System::EventHandler(this, &MainView::BtnCalcPlus_Click);
			// 
			// BtnCalcMinus
			// 
			this->BtnCalcMinus->Location = System::Drawing::Point(12, 106);
			this->BtnCalcMinus->Name = L"BtnCalcMinus";
			this->BtnCalcMinus->Size = System::Drawing::Size(117, 36);
			this->BtnCalcMinus->TabIndex = 3;
			this->BtnCalcMinus->Text = L"CalcMinus";
			this->BtnCalcMinus->UseVisualStyleBackColor = true;
			this->BtnCalcMinus->Click += gcnew System::EventHandler(this, &MainView::BtnCalcMinus_Click);
			// 
			// BtnUsetTuple
			// 
			this->BtnUsetTuple->Location = System::Drawing::Point(12, 148);
			this->BtnUsetTuple->Name = L"BtnUsetTuple";
			this->BtnUsetTuple->Size = System::Drawing::Size(117, 36);
			this->BtnUsetTuple->TabIndex = 4;
			this->BtnUsetTuple->Text = L"UsetTuple";
			this->BtnUsetTuple->UseVisualStyleBackColor = true;
			this->BtnUsetTuple->Click += gcnew System::EventHandler(this, &MainView::BtnUsetTuple_Click);
			// 
			// BtnOverLoad
			// 
			this->BtnOverLoad->Location = System::Drawing::Point(144, 148);
			this->BtnOverLoad->Name = L"BtnOverLoad";
			this->BtnOverLoad->Size = System::Drawing::Size(117, 36);
			this->BtnOverLoad->TabIndex = 8;
			this->BtnOverLoad->Text = L"OverLoad";
			this->BtnOverLoad->UseVisualStyleBackColor = true;
			this->BtnOverLoad->Click += gcnew System::EventHandler(this, &MainView::BtnOverLoad_Click);
			// 
			// BtnUseArray
			// 
			this->BtnUseArray->Location = System::Drawing::Point(144, 106);
			this->BtnUseArray->Name = L"BtnUseArray";
			this->BtnUseArray->Size = System::Drawing::Size(117, 36);
			this->BtnUseArray->TabIndex = 7;
			this->BtnUseArray->Text = L"UseArray";
			this->BtnUseArray->UseVisualStyleBackColor = true;
			this->BtnUseArray->Click += gcnew System::EventHandler(this, &MainView::BtnUseArray_Click);
			// 
			// BtnUseListClass
			// 
			this->BtnUseListClass->Location = System::Drawing::Point(144, 64);
			this->BtnUseListClass->Name = L"BtnUseListClass";
			this->BtnUseListClass->Size = System::Drawing::Size(117, 36);
			this->BtnUseListClass->TabIndex = 6;
			this->BtnUseListClass->Text = L"UseListClass";
			this->BtnUseListClass->UseVisualStyleBackColor = true;
			this->BtnUseListClass->Click += gcnew System::EventHandler(this, &MainView::BtnUseListClass_Click);
			// 
			// BtnUseClass
			// 
			this->BtnUseClass->Location = System::Drawing::Point(144, 22);
			this->BtnUseClass->Name = L"BtnUseClass";
			this->BtnUseClass->Size = System::Drawing::Size(117, 36);
			this->BtnUseClass->TabIndex = 5;
			this->BtnUseClass->Text = L"UseClass";
			this->BtnUseClass->UseVisualStyleBackColor = true;
			this->BtnUseClass->Click += gcnew System::EventHandler(this, &MainView::BtnUseClass_Click);
			// 
			// MainView
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 12);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(449, 479);
			this->Controls->Add(this->BtnOverLoad);
			this->Controls->Add(this->BtnUseArray);
			this->Controls->Add(this->BtnUseListClass);
			this->Controls->Add(this->BtnUseClass);
			this->Controls->Add(this->BtnUsetTuple);
			this->Controls->Add(this->BtnCalcMinus);
			this->Controls->Add(this->BtnCalcPlus);
			this->Controls->Add(this->TxbLog);
			this->Controls->Add(this->BtnHelloWorld);
			this->Name = L"MainView";
			this->Text = L"WCF Client C++";
			this->Load += gcnew System::EventHandler(this, &MainView::MainView_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	
		
	//-------------------------------------------------
	// �ϐ�
	//-------------------------------------------------
	System::String^ ServiceBaseAddr = "http://localhost:8081/Gabekore";
	IService^ _service = nullptr;
	ChannelFactory<IService^>^ _channel = nullptr;

	//-------------------------------------------------
	// WCF�T�[�r�X�I�[�v���^�N���[�Y�̏���
	//-------------------------------------------------
	/// <summary>
	/// WCF�T�[�r�X�J�n
	/// </summary>
	private:
		System::Void StartService() {

			if (_service != nullptr || _channel != nullptr)
			{
				return;
			}

			try {
				// �Q�Ɛݒ�FSystem.ServiceModel.dll
				EndpointAddress^ endpointAddr = gcnew EndpointAddress(ServiceBaseAddr);

				// �`���l�����\�z���T�[�r�X�Ăяo�����s��.
				_channel = gcnew ChannelFactory<IService^>(gcnew BasicHttpBinding());

				// �T�[�r�X�ւ̃v���L�V���擾.
				_service = _channel->CreateChannel(endpointAddr);
			}
			catch (CommunicationException^ ex) {
				// �G���[����
				// 
				// WCF�ł́A�T�[�r�X�ƃN���C�A���g�Ԃ̒ʐM���ɃG���[�����������ꍇ
				// CommunicationException���X���[�����B
				MessageBox::Show(ex->Message);
			}
		}

		 /// <summary>
		 /// WCF�T�[�r�X�I��
		 /// </summary>
		System::Void StopService()
		{
			if (_service == nullptr && _channel == nullptr)
			{
				return;
			}

			_channel->Close();
		
			_service = nullptr;
			_channel = nullptr;
		}



		/// <summary>
		/// Load�C�x���g�ŏ�������
		/// </summary>
		System::Void MainView_Load(System::Object^  sender, System::EventArgs^  e) {
		
		}



		//-------------------------------------------------
		// WCF�̌��J���\�b�h���R�[��
		//-------------------------------------------------
		System::Void BtnHelloWorld_Click(System::Object^  sender, System::EventArgs^  e) {
		
			SetLog("-- �� --", __FUNCTION__); 

			StartService();

			try {
				auto result = _service->HelloWorld("Pochi");

				SetLog(result, __FUNCTION__);
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);
		}

		System::Void BtnCalcPlus_Click(System::Object^  sender, System::EventArgs^  e) {

			SetLog("-- �� --", __FUNCTION__);

			StartService();

			try {
				auto result = _service->CalcPlus(9,4);

				SetLog(result.ToString(), __FUNCTION__);
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);
		}


		System::Void BtnCalcMinus_Click(System::Object^  sender, System::EventArgs^  e) {

			SetLog("-- �� --", __FUNCTION__);

			StartService();

			try {

				int result = 0;
				_service->CalcMinus(12, 8, result);

				SetLog(result.ToString(), __FUNCTION__);
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);

		}
		System::Void BtnUsetTuple_Click(System::Object^  sender, System::EventArgs^  e) {

			SetLog("-- �� --", __FUNCTION__);

			StartService();

			try {
				// ������
				// C:\Users\rakuda\.nuget\packages\system.valuetuple\4.5.0\ref\net47\System.ValueTuple.dll

				auto ret = _service->UsetTuple("���Y", 34);

				SetLog(ret.Item1 + "/" + ret.Item2.ToString(), __FUNCTION__);
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);

		}
		System::Void BtnUseClass_Click(System::Object^  sender, System::EventArgs^  e) {

			SetLog("-- �� --", __FUNCTION__);

			StartService();

			try {
				auto result = _service->UseClass(gcnew ArgClass(987, "654"));

				SetLog(result->Code.ToString() + "/" + result->Name, __FUNCTION__);
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);

		}
		System::Void BtnUseListClass_Click(System::Object^  sender, System::EventArgs^  e) {

			SetLog("-- �� --", __FUNCTION__);

			StartService();

			try {
				// List<>��using namespace System::Collections::Generic;���K�v
				auto argClasss = gcnew List<ArgClass^>();
				argClasss->Add(gcnew ArgClass(123, "abc"));
				argClasss->Add(gcnew ArgClass(456, "DEF"));
				argClasss->Add(gcnew ArgClass(789, "Ghi"));
				argClasss->Add(gcnew ArgClass(101112, "JkL"));

				auto result = _service->UseListClass(argClasss);
				//result->ForEach(r => r.)

				for each(RetClass^ r in result) {
					SetLog(r->Code.ToString() + "/" + r->Name, __FUNCTION__);
				}
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);

		}
		System::Void BtnUseArray_Click(System::Object^  sender, System::EventArgs^  e) {

			SetLog("-- �� --", __FUNCTION__);

			StartService();

			try {
				auto result = _service->UseArray(gcnew array<String^>{ "11", "222", "3333" });

				for each(int r in result) {
					SetLog(r.ToString(), __FUNCTION__);
				}
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);

		}
		System::Void BtnOverLoad_Click(System::Object^  sender, System::EventArgs^  e) {

			SetLog("-- �� --", __FUNCTION__);

			StartService();

			try {
				auto result = _service->UseOverLoad(8);

				SetLog(result, __FUNCTION__);
			}
			catch (CommunicationException^ ex) {
				MessageBox::Show(ex->Message);
				SetLog(ex->Message, __FUNCTION__);
			}
			SetLog("-- �� --", __FUNCTION__);
		}

		//-------------------------------------------------
		// Private
		//-------------------------------------------------
		/// <summary>
		/// ���O�p�e�L�X�g�{�b�N�X�Ƀe�L�X�g�\��
		/// </summary>
		/// <param name="log"></param>
		System::Void SetLog(String^ log, String^ mehodName)
		{
			TxbLog->Text += mehodName + " : " + log + Environment::NewLine;
		}





	};
}

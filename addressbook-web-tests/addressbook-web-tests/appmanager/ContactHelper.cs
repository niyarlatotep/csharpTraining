﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            :base(manager)
        {
        }

        public void Modify(ContactData contactToModify, ContactData newContactData) {
            OpenEditing(contactToModify);
            FillContactForm(newContactData);
            UpdateContact();
        }

        public void UpdateContact() {
            driver.FindElement(By.CssSelector("[name='update']")).Click();
        }

        public void OpenEditing(ContactData contact) {
            driver.FindElement(By.XPath($"//tbody//td[.='{contact.LastName}']/parent::tr//*[@title='Edit']")).Click();
        }

        public void Delete(ContactData contact) {
            SelectByCheckBox(contact);
            DeleteAccept();
        }

        public void DeleteAccept() {
            driver.FindElement(By.CssSelector("[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public void SelectByCheckBox(ContactData contact) {
            driver.FindElement(By.XPath($"//tbody//td[.='{contact.LastName}']/parent::tr//input")).Click();
        }

        public void Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitCreation();
        }
        public void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }
        public void InitContactCreation()
        {
            driver.FindElement(By.CssSelector("[href='edit.php']")).Click();
        }
        public void SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
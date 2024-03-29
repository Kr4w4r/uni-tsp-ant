﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    [TestClass]
    public class CTestTSPPointList
    {
        protected CTSPPoint TEST_POINT_1 = new CTSPPoint("Point1");
        protected CTSPPoint TEST_POINT_2 = new CTSPPoint("Point2");
        protected CTSPPoint TEST_POINT_3 = new CTSPPoint("Point3");

        [TestMethod]
        public void singletonTest()
        {
            CTSPPointList singletonObject = CTSPPointList.getInstance();

            Assert.AreSame(singletonObject, CTSPPointList.getInstance(), "getInstance gibt nicht das gleiche Objekt zurück");
        }

        [TestMethod]
        public void insertTest()
        {
            CTSPPointList pointlist = CTSPPointList.getInstance();
            pointlist.removeAll();
            
            pointlist.addPoint(TEST_POINT_1);
            Assert.IsTrue(pointlist.length() == 1);

            pointlist.addPoint(TEST_POINT_2);
            Assert.IsTrue(pointlist.length() == 2);

            pointlist.addPoint(TEST_POINT_3);
            Assert.IsTrue(pointlist.length() == 3);

            Assert.AreSame(pointlist.getPoint(0), TEST_POINT_1, "zuerste in die Liste eingefügter Punkt entsprecht nicht dem eingefügten Objekt");
            Assert.AreSame(pointlist.getPoint(1), TEST_POINT_2, "zuerste in die Liste eingefügter Punkt entsprecht nicht dem eingefügten Objekt");
            Assert.AreSame(pointlist.getPoint(2), TEST_POINT_3, "zuerste in die Liste eingefügter Punkt entsprecht nicht dem eingefügten Objekt");

            // Testdaten löschen
            pointlist.removeAll();
        }

        [TestMethod]
        public void deleteAllTest()
        {
            CTSPPointList pointlist = CTSPPointList.getInstance();

            pointlist.addPoint(TEST_POINT_1);
            pointlist.addPoint(TEST_POINT_2);
            pointlist.addPoint(TEST_POINT_3);
            Assert.IsTrue(pointlist.length() == 3, "Fehler beim einfügen der Testdaten");

            pointlist.removeAll();

            Assert.IsTrue(pointlist.length() == 0);

            // Testdaten löschen
            pointlist.removeAll();
        }

        [TestMethod]
        public void testDeleteSingleEntry()
        {
            CTSPPointList pointlist = CTSPPointList.getInstance();

            pointlist.addPoint(TEST_POINT_1);
            pointlist.addPoint(TEST_POINT_2);
            pointlist.addPoint(TEST_POINT_3);
            Assert.IsTrue(pointlist.length() == 3, "Fehler beim einfügen der Testdaten");

            // ersten eintrag löschen, also ein Eintrag weniger
            pointlist.remove(0);
            Assert.IsTrue(pointlist.length() == 2);

            Assert.AreSame(pointlist.getPoint(0), TEST_POINT_2);
            Assert.AreSame(pointlist.getPoint(1), TEST_POINT_3);

            // Testdaten löschen
            pointlist.removeAll();
        }

        [TestMethod]
        public void testDeleteSpecificPoint()
        {
            CTSPPointList pointlist = CTSPPointList.getInstance();

            pointlist.addPoint(TEST_POINT_1);
            pointlist.addPoint(TEST_POINT_2);
            pointlist.addPoint(TEST_POINT_3);
            Assert.IsTrue(pointlist.length() == 3, "Fehler beim einfügen der Testdaten");

            // den Punkt2 aus der Liste löschen
            pointlist.remove(TEST_POINT_2);
            Assert.IsTrue(pointlist.length() == 2);

            // Der Punkt 2 darf nicht mehr vorhanden sein
            foreach (CTSPPoint point in pointlist)
            {
                Assert.AreNotSame(point, TEST_POINT_2);
            }

            // Testdaten löschen
            pointlist.removeAll();
        }

        [TestMethod]
        public void testDeletePointNotExistent()
        {
            CTSPPointList pointlist = CTSPPointList.getInstance();

            pointlist.addPoint(TEST_POINT_1);
            pointlist.addPoint(TEST_POINT_2);
            pointlist.addPoint(TEST_POINT_3);
            Assert.IsTrue(pointlist.length() == 3, "Fehler beim einfügen der Testdaten");

            // dieser Index sollte nicht vorhanden sein, es darf also nichts gelöscht werden
            pointlist.remove(100);
            Assert.IsTrue(pointlist.length() == 3);

            // löschen eines Punktes der nicht in der Liste ist
            pointlist.remove(new CTSPPoint());
            Assert.IsTrue(pointlist.length() == 3);

            // Testdaten löschen
            pointlist.removeAll();
        }

        [TestMethod]
        public void lengthTest()
        {
            CTSPPointList pointlist = CTSPPointList.getInstance();

            for (int i = 0; i < 1000; i++)
            {
                pointlist.addPoint(new CTSPPoint());
                Assert.IsTrue(pointlist.length() == i+1);
            }

            // Testdaten löschen
            pointlist.removeAll();
        }

        [TestMethod]
        public void copyTest()
        {
            CTSPPointList pointlist = CTSPPointList.getInstance();

            pointlist.addPoint(TEST_POINT_1);
            pointlist.addPoint(TEST_POINT_2);
            pointlist.addPoint(TEST_POINT_3);
            Assert.IsTrue(pointlist.length() == 3, "Fehler beim einfügen der Testdaten");

            CTSPPointList copy = pointlist.copy();

            Assert.AreNotSame(pointlist, copy);
            Assert.IsTrue(pointlist.length() == copy.length());
        }

        [TestInitialize]
        public void initTest()
        {
            cleanTest();
        }

        [TestCleanup]
        public void cleanTest()
        {
            CTSPPointList.getInstance().removeAll();
        }
    }
}
